using Godot;
using System;
using System.Linq;

public partial class CampaignMap:Control
{
    public int RegionIndex,Completed;
    public Action<int>? StageChosen;
    private Texture2D art=null!;
    private readonly System.Collections.Generic.List<StageIsland> islands=new();
    // Authored landmarks on the actual walkable bridges and terraces, per painting.
    public static readonly Vector2[][] Routes={
        new Vector2[]{new(.34f,.79f),new(.44f,.73f),new(.58f,.69f),new(.64f,.61f),new(.55f,.55f),new(.45f,.48f),new(.56f,.45f),new(.64f,.40f),new(.76f,.37f),new(.72f,.29f)},
        new Vector2[]{new(.65f,.77f),new(.56f,.68f),new(.49f,.60f),new(.47f,.52f),new(.57f,.47f),new(.61f,.41f),new(.57f,.35f),new(.70f,.31f),new(.65f,.23f),new(.50f,.17f)},
        new Vector2[]{new(.73f,.70f),new(.64f,.65f),new(.53f,.65f),new(.46f,.58f),new(.30f,.56f),new(.37f,.49f),new(.47f,.46f),new(.58f,.40f),new(.53f,.35f),new(.43f,.30f)},
        new Vector2[]{new(.33f,.76f),new(.29f,.69f),new(.22f,.57f),new(.28f,.49f),new(.39f,.47f),new(.50f,.40f),new(.54f,.33f),new(.48f,.27f),new(.56f,.23f),new(.58f,.16f)},
        new Vector2[]{new(.30f,.78f),new(.40f,.72f),new(.48f,.66f),new(.56f,.60f),new(.63f,.55f),new(.61f,.48f),new(.56f,.44f),new(.49f,.40f),new(.56f,.30f),new(.62f,.25f)},
        new Vector2[]{new(.30f,.68f),new(.39f,.72f),new(.49f,.66f),new(.64f,.63f),new(.77f,.58f),new(.89f,.52f),new(.82f,.47f),new(.68f,.44f),new(.58f,.40f),new(.44f,.38f)},
        new Vector2[]{new(.49f,.76f),new(.52f,.67f),new(.54f,.55f),new(.40f,.53f),new(.26f,.52f),new(.19f,.41f),new(.30f,.32f),new(.42f,.33f),new(.55f,.35f),new(.55f,.25f)}
    };
    public override void _Ready(){
        art=GD.Load<Texture2D>(JourneyData.Regions[RegionIndex].Art);MouseFilter=MouseFilterEnum.Ignore;
        for(int i=0;i<10;i++){
            int stage=RegionIndex*10+i+1;bool boss=stage%10==0,cleared=stage<=Completed;
            var node=new StageIsland{Stage=stage,Cleared=cleared,Boss=boss,Next=stage==Completed+1,Disabled=stage>Completed+1||cleared&&boss,TooltipText=$"Fase {stage} • "+(cleared&&boss?"Chefe concluído • Treinamento para reencontros elegíveis":stage>Completed+1?"Conclua a fase anterior":cleared?"Repetir • Gold":"Explorar este caminho")};
            node.Pressed+=()=>StageChosen?.Invoke(stage);AddChild(node);islands.Add(node);
        }
        Resized+=Place;Place();
    }
    private void Place(){for(int i=0;i<islands.Count;i++){islands[i].Position=Routes[RegionIndex][i]*Size-new Vector2(42,52);islands[i].Size=new Vector2(84,84);}}
    public override void _Draw(){if(art==null)return;DrawTextureRect(art,new Rect2(Vector2.Zero,Size),false);DrawRect(new Rect2(Vector2.Zero,Size),new Color(.015f,.025f,.045f,.13f));}
}
public partial class StageIsland:Button
{
    public int Stage;public bool Cleared,Boss,Next;private double clock;
    public override void _Ready(){foreach(var state in new[]{"normal","hover","pressed","disabled","focus"})AddThemeStyleboxOverride(state,new StyleBoxEmpty());}
    public override void _Process(double delta){clock+=delta;QueueRedraw();}
    public override void _Draw(){
        var c=new Vector2(42,42);var accent=Next?EnigmaStyle.Ivory:Cleared?new Color("8de4cd"):EnigmaStyle.Gold;
        float radius=Next?29:22;
        DrawSetTransform(c+new Vector2(0,12),0,new Vector2(1,.33f));DrawCircle(Vector2.Zero,radius+9,new Color(0,0,0,.55f));DrawArc(Vector2.Zero,radius+11,0,Mathf.Tau,40,new Color(accent,.65f),2,true);DrawSetTransform(Vector2.Zero);
        if(Next){float pulse=(Mathf.Sin((float)clock*2)+1)/2;DrawCircle(c,radius+7+pulse*5,new Color(accent,.1f));for(int i=0;i<6;i++){float t=((float)clock*.25f+i/6f)%1;DrawCircle(c+new Vector2(Mathf.Sin(i*4)*30,-t*55),1.5f,new Color(accent,1-t));}}
        DrawCircle(c,radius,new Color("101c28"));DrawArc(c,radius,0,Mathf.Tau,48,accent,Next||IsHovered()?3:1.5f,true);
        if(Disabled&&!Cleared&&!Boss)EnigmaStyle.Lock(this,c,.8f);
        else if(Boss){DrawColoredPolygon(new[]{c+new Vector2(-15,9),c+new Vector2(-17,-10),c+new Vector2(-7,-2),c+new Vector2(0,-17),c+new Vector2(7,-2),c+new Vector2(17,-10),c+new Vector2(15,9)},accent);}
        else if(Cleared){DrawPolyline(new[]{c+new Vector2(-10,0),c+new Vector2(-3,7),c+new Vector2(12,-9)},accent,3,true);}
        else{EnigmaStyle.Sword(this,c,-.6f,20,accent);EnigmaStyle.Sword(this,c,.6f,20,accent);}
        string label=Next?"Explorar":Boss?"Chefe":IsHovered()?"Fase "+Stage:"";
        if(label!=""){DrawStringOutline(EnigmaStyle.Font,new Vector2(-13,82),label,HorizontalAlignment.Center,110,13,5,Colors.Black);DrawString(EnigmaStyle.Font,new Vector2(-13,82),label,HorizontalAlignment.Center,110,13,accent);}
    }
}
