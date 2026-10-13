"""Gera um cenario Unreal real. Executar no Editor; nenhuma simulacao HTML."""
import math
import random
import unreal as u

random.seed(70)
assets = u.AssetToolsHelpers.get_asset_tools()
actors = u.get_editor_subsystem(u.EditorActorSubsystem)
levels = u.get_editor_subsystem(u.LevelEditorSubsystem)
ROOT = '/Game/Enigma'
MAP = ROOT + '/Maps/ForestArena'
# Reconstrucao explicita somente deste mapa gerado; nao opera em mapas de producao.
world = u.EditorLoadingAndSavingUtils.new_blank_map(False)

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
    obj = actors.spawn_actor_from_class(u.StaticMeshActor, u.Vector(*pos), u.Rotator(0,yaw,0))
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
sun=actors.spawn_actor_from_class(u.DirectionalLight,u.Vector(0,0,800),u.Rotator(-35,-35,0))
sun.set_actor_label('Warm canopy light')
sun.light_component.set_editor_property('intensity',3.5)
sun.light_component.set_light_color(u.LinearColor(1,.79,.52))
sky=actors.spawn_actor_from_class(u.SkyLight,u.Vector(0,0,500))
sky.light_component.set_editor_property('intensity',.8)
sky.light_component.set_editor_property('real_time_capture', True)
actors.spawn_actor_from_class(u.SkyAtmosphere,u.Vector(0,0,0))
fog=actors.spawn_actor_from_class(u.ExponentialHeightFog,u.Vector(0,0,-80))
fog.component.set_editor_property('fog_density',.015)
fog.component.set_editor_property('enable_volumetric_fog', True)
camera=actors.spawn_actor_from_class(u.CineCameraActor,u.Vector(1150,-1550,1050))
camera.set_actor_label('Combat camera')
camera.set_actor_rotation(u.MathLibrary.find_look_at_rotation(camera.get_actor_location(),u.Vector(0,0,90)),False)
camera.get_cine_camera_component().set_editor_property('current_focal_length',35)
u.get_editor_subsystem(u.UnrealEditorSubsystem).set_level_viewport_camera_info(camera.get_actor_location(),camera.get_actor_rotation())
if not u.EditorLoadingAndSavingUtils.save_map(world, MAP):
    raise RuntimeError('Nao foi possivel salvar '+MAP)
u.EditorAssetLibrary.save_directory(ROOT)
u.log('ENIGMA_SCENE_READY: '+MAP)
