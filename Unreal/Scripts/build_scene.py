"""Gera um cenario Unreal real. Executar no Editor; nenhuma simulacao HTML."""
import math
import random
import pathlib
import unreal as u

random.seed(70)
assets = u.AssetToolsHelpers.get_asset_tools()
actors = u.get_editor_subsystem(u.EditorActorSubsystem)
levels = u.get_editor_subsystem(u.LevelEditorSubsystem)
ROOT = '/Game/Enigma'
MAP = ROOT + '/Maps/ForestArena'
# Reconstrucao explicita somente deste mapa gerado; nao opera em mapas de producao.
world = u.EditorLoadingAndSavingUtils.new_blank_map(False)
if not u.EditorLoadingAndSavingUtils.save_map(world, MAP):
    raise RuntimeError('Falha ao criar mapa com caminho persistente')

def material(name, rgb, metallic=0.0, roughness=0.7, emission=0):
    path = ROOT + '/Materials/' + name
    m = u.load_asset(path)
    if m:
        return m
    m = assets.create_asset(name, ROOT + '/Materials', u.Material, u.MaterialFactoryNew())
    color = u.MaterialEditingLibrary.create_material_expression(m, u.MaterialExpressionConstant3Vector)
    color.set_editor_property('constant', u.LinearColor(*rgb, 1))
    u.MaterialEditingLibrary.connect_material_property(color, '', u.MaterialProperty.MP_BASE_COLOR)
    for prop, value in [(u.MaterialProperty.MP_METALLIC, metallic), (u.MaterialProperty.MP_ROUGHNESS, roughness)]:
        node = u.MaterialEditingLibrary.create_material_expression(m, u.MaterialExpressionConstant)
        node.set_editor_property('r', value)
        u.MaterialEditingLibrary.connect_material_property(node, '', prop)
    if emission:
        light = u.MaterialEditingLibrary.create_material_expression(m, u.MaterialExpressionConstant3Vector)
        light.set_editor_property('constant', u.LinearColor(*(v*emission for v in rgb), 1))
        u.MaterialEditingLibrary.connect_material_property(light, '', u.MaterialProperty.MP_EMISSIVE_COLOR)
    u.MaterialEditingLibrary.recompile_material(m)
    u.EditorAssetLibrary.save_loaded_asset(m)
    return m

stone = material('M_WeatheredStone', (.16,.22,.21), .15, .8)
dark = material('M_ForestFloor', (.035,.07,.052), 0, .97)
gold = material('M_AgedBronze', (.35,.19,.065), .75, .4)
glow = material('M_Rift', (.12,.015,.38), .3, .25, 3)

def static(name, mesh_path, pos, scale, mat=None, yaw=0):
    obj = actors.spawn_actor_from_class(u.StaticMeshActor, u.Vector(*pos), u.Rotator(pitch=0,yaw=yaw,roll=0))
    obj.set_actor_label(name)
    obj.static_mesh_component.set_static_mesh(u.load_asset(mesh_path))
    obj.set_actor_scale3d(u.Vector(*scale))
    if mat:
        obj.static_mesh_component.set_material(0,mat)
    return obj

cube = '/Engine/BasicShapes/Cube.Cube'
cylinder = '/Engine/BasicShapes/Cylinder.Cylinder'
static('Forest foundation',cube,(0,0,-45),(32,32,.8),dark)
static('Arena',cylinder,(0,0,-12),(15,15,.25),stone)
for ring in range(3):
    radius=410+ring*105
    for j in range(28):
        a=2*math.pi*j/28 + ring*.04
        static('Radial masonry',cube,(radius*math.cos(a),radius*math.sin(a),3),(.94,.65,.09),stone,math.degrees(a))
for i in range(18):
    a=2*math.pi*i/18
    # Keep foreground open for the combat camera.
    if math.sin(a)<-.55:
        continue
    r=1000+random.uniform(0,450)
    static('Oak', '/Game/SampleScene/Tree/HillTree_02.HillTree_02', (math.cos(a)*r,math.sin(a)*r,-30),(.55,.55,.65),yaw=random.randrange(360))
for i in range(9):
    a=math.pi*i/8
    x,y=math.cos(a)*850,math.sin(a)*850
    h=random.uniform(1.8,3.5)
    static('Ruined column',cylinder,(x,y,h*50),(.55,.55,h),stone)
    static('Bronze capital',cylinder,(x,y,h*100),(.75,.75,.16),gold)
    static('Rift crystal', '/Engine/BasicShapes/Cone.Cone',(x,y,h*100+38),(.25,.25,.7),glow)
sun=actors.spawn_actor_from_class(u.DirectionalLight,u.Vector(0,0,800),u.Rotator(pitch=-35,yaw=-35,roll=0))
sun.light_component.set_mobility(u.ComponentMobility.MOVABLE)
sun.set_actor_label('Warm canopy light')
sun.light_component.set_editor_property('intensity',3.5)
sun.light_component.set_editor_property('atmosphere_sun_light',True)
sun.light_component.set_light_color(u.LinearColor(1,.79,.52))
sky=actors.spawn_actor_from_class(u.SkyLight,u.Vector(0,0,500))
sky.light_component.set_mobility(u.ComponentMobility.MOVABLE)
sky.light_component.set_editor_property('intensity',2.0)
sky.light_component.set_editor_property('real_time_capture', True)
actors.spawn_actor_from_class(u.SkyAtmosphere,u.Vector(0,0,0))
fog=actors.spawn_actor_from_class(u.ExponentialHeightFog,u.Vector(0,0,-80))
fog.component.set_editor_property('fog_density',.015)
fog.component.set_editor_property('enable_volumetric_fog', True)
camera=actors.spawn_actor_from_class(u.CineCameraActor,u.Vector(0,-1450,950))
camera.set_actor_label('Combat camera')
camera.set_actor_rotation(u.MathLibrary.find_look_at_rotation(camera.get_actor_location(),u.Vector(0,0,90)),False)
camera.get_cine_camera_component().set_editor_property('current_focal_length',35)
# Cinematica de demonstracao. Modelos Epic sao substitutos, nao Kael final.
cyan = material('M_EssenceCyan', (.01,.5,.7), .1,.3,7)
ice = material('M_Ice', (.12,.48,.65), .45,.16,1)
def fighter(name, location, yaw, tint=None):
    obj=actors.spawn_actor_from_class(u.SkeletalMeshActor,u.Vector(*location),u.Rotator(pitch=0,yaw=yaw,roll=0))
    obj.set_actor_label(name)
    comp=obj.skeletal_mesh_component
    comp.set_skeletal_mesh_asset(u.load_asset('/Game/Characters/Mannequins/Meshes/SKM_Manny_Simple'))
    if tint:
        for index in range(comp.get_num_materials()):
            comp.set_material(index,tint)
    return obj
hero=fighter('Heroi TEMPORARIO - Manny',(-260,0,8),-90)
enemy=fighter('Alvo TEMPORARIO - Manny',(210,0,8),90,material('M_TargetArmor',(.14,.035,.22),.65,.4))

sequence_path=ROOT+'/Sequences/CombatStudy'
sequence=u.load_asset(sequence_path)
if sequence:
    # Asset local gerado: limpa apenas as faixas deste estudo.
    for binding in sequence.get_bindings():
        binding.remove()
    for track in sequence.get_tracks():
        sequence.remove_track(track)
else:
    sequence=assets.create_asset('CombatStudy',ROOT+'/Sequences',u.LevelSequence,u.LevelSequenceFactoryNew())
sequence.set_display_rate(u.FrameRate(30,1))
sequence.set_playback_start(0)
sequence.set_playback_end(300)

def transforms(obj, keys):
    obj.root_component.set_mobility(u.ComponentMobility.MOVABLE)
    binding=sequence.add_possessable(obj)
    track=binding.add_track(u.MovieScene3DTransformTrack)
    section=track.add_section()
    section.set_range(0,300)
    channels=section.get_all_channels()
    for frame,loc,rot,scale in keys:
        values=(*loc,*rot,*scale)
        for channel,value in zip(channels,values):
            channel.add_key(u.FrameNumber(frame),float(value),interpolation=u.MovieSceneKeyInterpolation.LINEAR)
    return binding

hb=transforms(hero,[(0,(-260,0,8),(0,0,0),(1,1,1)),(30,(-260,0,8),(0,0,0),(1,1,1)),(60,(70,0,8),(0,0,0),(1,1,1)),(94,(70,0,8),(0,0,0),(1,1,1)),(130,(-260,0,8),(0,0,0),(1,1,1)),(299,(-260,0,8),(0,0,0),(1,1,1))])
eb=transforms(enemy,[(0,(210,0,8),(0,0,180),(1,1,1)),(72,(210,0,8),(0,0,180),(1,1,1)),(80,(235,0,8),(0,0,180),(1,1,1)),(115,(210,0,8),(0,0,180),(1,1,1)),(299,(210,0,8),(0,0,180),(1,1,1))])
idle='/Game/Characters/Mannequins/Anims/Unarmed/MM_Idle'
jog='/Game/Characters/Mannequins/Anims/Unarmed/Jog/MF_Unarmed_Jog_Fwd'
attack='/Game/Characters/Mannequins/Anims/Unarmed/Attack/MM_Attack_01'
charge='/Game/Characters/Mannequins/Anims/Unarmed/Attack/MM_ChargedAttack'
hit='/Game/Characters/Mannequins/Anims/Rifle/HitReact/MM_HitReact_Front_Med_01'
def animate(binding, segments):
    track=binding.add_track(u.MovieSceneSkeletalAnimationTrack)
    for start,end,path in segments:
        clip=u.load_asset(path)
        if not clip:
            raise RuntimeError('Animacao ausente: '+path)
        section=track.add_section()
        section.set_range(start,end)
        params=section.get_editor_property('params')
        params.set_editor_property('animation',clip)
        section.set_editor_property('params',params)
animate(hb,[(0,30,idle),(30,60,jog),(60,94,attack),(94,130,jog),(130,165,idle),(165,205,charge),(205,300,idle)])
animate(eb,[(0,73,idle),(73,112,hit),(112,194,idle),(194,224,hit),(224,300,idle)])
# O esqueleto Manny aponta para +Y. Corrige somente a orientacao visual das faixas.
for binding,yaw in [(hb,-90),(eb,90)]:
    transform_track=binding.find_tracks_by_type(u.MovieScene3DTransformTrack)[0]
    channel=transform_track.get_sections()[0].get_all_channels()[5]
    for key in channel.get_keys():
        key.set_value(yaw)

# Malha de arco original: fita afilada com espessura, nao um torus inteiro.
vertices=[]
for j in range(49):
    t=j/48
    a=-1.4+t*2.8
    width=2+18*math.sin(math.pi*t)
    for radius,z in [(100-width,-2),(100+width,-2),(100-width,2),(100+width,2)]:
        vertices.append((radius*math.cos(a),radius*math.sin(a),z))
lines=['v %.5f %.5f %.5f'%v for v in vertices]
lines += ['vt %.5f %.5f'%(j/48,k/3) for j in range(49) for k in range(4)]
for j in range(48):
    n=j*4+1
    for face in [(n,n+4,n+5,n+1),(n+2,n+3,n+7,n+6),(n,n+2,n+6,n+4),(n+1,n+5,n+7,n+3)]:
        lines.append('f '+' '.join('%d/%d'%(v,v) for v in face))
source=pathlib.Path(u.Paths.project_saved_dir())/'Crescent.obj'
source.parent.mkdir(parents=True,exist_ok=True)
source.write_text('\n'.join(lines))
task=u.AssetImportTask()
task.set_editor_property('filename',str(source.resolve()))
task.set_editor_property('destination_path',ROOT+'/Meshes')
task.set_editor_property('destination_name','Crescent')
task.set_editor_property('automated',True)
task.set_editor_property('replace_existing',True)
task.set_editor_property('save',True)
assets.import_asset_tasks([task])
arc=static('Corte de essencia',ROOT+'/Meshes/Crescent',(135,0,105),(1,1,1),cyan)
transforms(arc,[(0,(135,0,105),(20,0,-65),(0,0,0)),(69,(135,0,105),(20,0,-65),(0,0,0)),(71,(135,0,105),(20,0,-40),(1,1,1)),(77,(170,0,105),(20,0,65),(1.3,1.3,1.3)),(84,(170,0,105),(20,0,95),(0,0,0)),(299,(170,0,105),(20,0,95),(0,0,0))])
for j in range(10):
    a=2*math.pi*j/10
    loc=(210+math.cos(a)*70,math.sin(a)*70,55)
    crystal=static('Ruptura glacial', '/Engine/BasicShapes/Cone.Cone',loc,(.24,.24,1.2),ice)
    transforms(crystal,[(0,loc,(0,0,0),(0,0,0)),(192,loc,(0,0,0),(0,0,0)),(199,loc,(0,0,0),(.24,.24,1.2)),(249,loc,(0,0,0),(.24,.24,1.2)),(270,loc,(0,0,0),(0,0,0)),(299,loc,(0,0,0),(0,0,0))])
cb=sequence.add_possessable(camera)
cut=sequence.add_track(u.MovieSceneCameraCutTrack).add_section()
cut.set_range(0,300)
binding_id=u.MovieSceneObjectBindingID()
binding_id.set_editor_property('guid',cb.get_id())
cut.set_camera_binding_id(binding_id)
seq_actor=actors.spawn_actor_from_class(u.LevelSequenceActor,u.Vector())
seq_actor.set_actor_label('DEMO - sequencia automatica 10 segundos')
seq_actor.set_sequence(sequence)
settings=seq_actor.get_editor_property('playback_settings')
settings.set_editor_property('auto_play',True)
settings.set_editor_property('loop_count',u.MovieSceneSequenceLoopCount(-1))
seq_actor.set_editor_property('playback_settings',settings)
# Evita a esfera do DefaultPawn aparecendo no centro durante a cinematica.
gm_path=ROOT+'/BP_CinematicMode'
gm=u.load_asset(gm_path)
if not gm:
    factory=u.BlueprintFactory()
    factory.set_editor_property('parent_class',u.GameModeBase)
    gm=assets.create_asset('BP_CinematicMode',ROOT,u.Blueprint,factory)
gm_class=gm.generated_class()
u.get_default_object(gm_class).set_editor_property('default_pawn_class',None)
world.get_world_settings().set_editor_property('default_game_mode',gm_class)
u.EditorAssetLibrary.save_loaded_asset(gm)
u.EditorAssetLibrary.save_loaded_asset(sequence)
u.get_editor_subsystem(u.UnrealEditorSubsystem).set_level_viewport_camera_info(camera.get_actor_location(),camera.get_actor_rotation())
if not u.EditorLoadingAndSavingUtils.save_map(world, MAP):
    raise RuntimeError('Nao foi possivel salvar '+MAP)
u.EditorAssetLibrary.save_directory(ROOT)
for binding in sequence.get_bindings():
    bound=u.MovieSceneSequenceExtensions.locate_bound_objects(sequence,binding,world)
    if not bound:
        raise RuntimeError('Binding sem ator: '+binding.get_name())
u.log('ENIGMA_SCENE_READY: '+MAP)
