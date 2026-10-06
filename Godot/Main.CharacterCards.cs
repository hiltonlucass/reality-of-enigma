using Godot;
using Vaelorn;
using System;
using System.Linq;

public partial class Main
{
    private void ShowCharacterCards()
    {
        var root=NewMenuRoot();
        var backdrop=new ColorRect{Color=new Color("0a1421"),MouseFilter=MouseFilterEnum.Ignore};root.AddChild(backdrop);Place(backdrop,0,0,1,1);
        var forest=new TextureRect{Texture=GD.Load<Texture2D>("res://Art/fenrath-background-v29.png"),ExpandMode=TextureRect.ExpandModeEnum.IgnoreSize,StretchMode=TextureRect.StretchModeEnum.KeepAspectCovered,MouseFilter=MouseFilterEnum.Ignore,Visible=false};root.AddChild(forest);Place(forest,0,0,1,1);
        var shade=new ColorRect{Color=new Color(.02f,.025f,.06f,.88f),MouseFilter=MouseFilterEnum.Ignore,Visible=false};root.AddChild(shade);Place(shade,.47f,0,1,1);
        var art=new HeroBanner{HeroIndex=0};root.AddChild(art);Place(art,0,0,.45f,1);
        var right=new VBoxContainer();root.AddChild(right);Place(right,.49f,.045f,.96f,.95f);right.AddThemeConstantOverride("separation",14);
        var top=new HBoxContainer();right.AddChild(top);var heading=MenuLabel("HERÓIS REVELADOS",18);heading.SizeFlagsHorizontal=SizeFlags.ExpandFill;top.AddChild(heading);Button(top,"Voltar",ShowHomeMenu);
        var roster=new HBoxContainer{Name="HeroRoster"};roster.AddThemeConstantOverride("separation",8);right.AddChild(roster);
        var scroll=new ScrollContainer{SizeFlagsVertical=SizeFlags.ExpandFill};right.AddChild(scroll);
        var info=new VBoxContainer{SizeFlagsHorizontal=SizeFlags.ExpandFill};info.AddThemeConstantOverride("separation",14);scroll.AddChild(info);
        void Render(int index){
            art.HeroIndex=index;
            forest.Visible=index==5;shade.Visible=index==5;
            foreach(var child in info.GetChildren()){info.RemoveChild(child);child.QueueFree();}
            string id=JourneyData.Revealed[index];var hero=game.Catalog.Hero(id);var owned=game.Save.Roster.FirstOrDefault(o=>o.Id==id);var unit=new Unit(hero,owned?.Level??1,path:owned?.Path??"base");var story=JourneyData.Stories[id];
            var name=MenuLabel(hero.Name.ToUpperInvariant(),42);name.AddThemeColorOverride("font_color",new Color("efcf91"));info.AddChild(name);info.AddChild(MenuLabel(story.Title,20));
            info.AddChild(MenuLabel(owned==null?"REVELADO • AINDA NÃO RECRUTADO":$"NÍVEL {owned.Level}   {new string('★',owned.Stars)}",16));
            info.AddChild(MenuLabel("FUNÇÃO  /  "+hero.Role,16));
            info.AddChild(MenuLabel("ARQUÉTIPO  /  "+string.Join(" • ",unit.Archetypes.Select(a=>game.Catalog.Archetypes.Single(x=>x.Id==a).Name)),18));
            info.AddChild(MenuLabel("VÍNCULO  /  "+story.Affiliation,14));
            var stats=new HFlowContainer();info.AddChild(stats);
            foreach(var value in new[]{("VIDA",unit.MaxHp),("FORÇA",unit.Strength),("ESSÊNCIA",unit.Essence),("DEFESA",unit.Defense),("VELOCIDADE",unit.Speed)}){
                var stat=MenuLabel($"{value.Item1}\n{value.Item2:N0}",15);stat.CustomMinimumSize=new Vector2(118,46);stat.AutowrapMode=TextServer.AutowrapMode.Off;stats.AddChild(stat);
            }
            if(id is "varkas" or "sevrin")Button(info,"Testar "+hero.Name+" em combate",()=>Start(id));
            info.AddChild(MenuLabel("HABILIDADES • clique para consultar",18));
            var icons=new HFlowContainer{Name="HeroSkills"};info.AddChild(icons);
            var description=MenuLabel("Selecione uma habilidade ou a passiva. As ações pendentes não concedem efeitos.",16);description.CustomMinimumSize=new Vector2(0,78);
            var skills=new Battle(game.Catalog,new[]{unit},Array.Empty<Unit>()).SkillsFor(unit);
            foreach(var ability in skills){var b=new SkillIconButton{Ability=ability,CustomMinimumSize=new Vector2(86,88),TooltipText=ability.Name};b.Pressed+=()=>description.Text=DescribeSkill(ability);icons.AddChild(b);}
            var passive=new SkillIconButton{Passive=true,CustomMinimumSize=new Vector2(86,94),TooltipText="Consultar passiva"};passive.Pressed+=()=>description.Text=PassiveDescription(unit);icons.AddChild(passive);info.AddChild(description);
            info.AddChild(MenuLabel("SINERGIAS",18));
            info.AddChild(MenuLabel(unit.Archetypes.Contains("fighter")?"Lutadores: 2 → +10% dano ao time; 3 → +30% crítico aos Lutadores; 4 → 12% redução de dano; 5 → +15% velocidade. Valores provisórios e cumulativos.":"Este arquétipo é contado separadamente da função de combate. Sua sinergia específica ainda está em desenvolvimento.",15));
            info.AddChild(MenuLabel("HISTÓRIA",20));info.AddChild(MenuLabel(story.History,17));
        }
        var atlas=GD.Load<Texture2D>("res://Art/hero-banners-v23.png");
        for(int i=0;i<JourneyData.Revealed.Length;i++){
            int index=i;var column=new VBoxContainer();roster.AddChild(column);
            var b=new TextureButton{Name="Hero_"+JourneyData.Revealed[i],TextureNormal=new AtlasTexture{Atlas=i==6?GD.Load<Texture2D>("res://Art/sevrin-portrait-v30.png"):i==5?GD.Load<Texture2D>("res://Art/fenrath-portrait-v30.png"):atlas,Region=HeroBanner.Region(i==6?GD.Load<Texture2D>("res://Art/sevrin-portrait-v30.png"):i==5?GD.Load<Texture2D>("res://Art/fenrath-portrait-v30.png"):atlas,i,true)},IgnoreTextureSize=true,StretchMode=TextureButton.StretchModeEnum.KeepAspectCovered,CustomMinimumSize=new Vector2(65,70),TooltipText=game.Catalog.Hero(JourneyData.Revealed[i]).Name};b.Pressed+=()=>Render(index);column.AddChild(b);if(i==5){var bg=new TextureRect{Texture=GD.Load<Texture2D>("res://Art/fenrath-background-v29.png"),ExpandMode=TextureRect.ExpandModeEnum.IgnoreSize,StretchMode=TextureRect.StretchModeEnum.KeepAspectCovered,MouseFilter=MouseFilterEnum.Ignore,ShowBehindParent=true};b.AddChild(bg);bg.SetAnchorsAndOffsetsPreset(LayoutPreset.FullRect);}column.AddChild(MenuLabel(game.Catalog.Hero(JourneyData.Revealed[i]).Name,13));
        }
        Render(0);
    }
}

