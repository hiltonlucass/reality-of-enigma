using Godot;
using Vaelorn;
using System;
using System.Linq;
public partial class SkillIconButton:Button
{
    public Skill Ability=null!;
    private Texture2D atlas=null!;private Texture2D? feralAtlas,modernAtlas;
    public bool Passive;
    private static System.Collections.Generic.Dictionary<string,int>? cells;
    public static int CellFor(string id){cells??=System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.Dictionary<string,int>>(Godot.FileAccess.GetFileAsString("res://Data/skill-icons.json"))!;return cells.TryGetValue(id,out int n)?n:throw new InvalidOperationException("Ícone ausente: "+id);}
    public override void _Ready(){atlas=GD.Load<Texture2D>("res://Art/skills-v22.png");foreach(var state in new[]{"normal","hover","pressed","disabled","focus"})AddThemeStyleboxOverride(state,new StyleBoxEmpty());}
    public override void _Draw(){
        if(atlas==null)return;
        int cell=Passive?23:CellFor(Ability.Id);bool modern=cell>=40,feral=cell>=25&&!modern;
        var texture=modern?(modernAtlas??=GD.Load<Texture2D>("res://Art/skills-v30.png")):feral?(feralAtlas??=GD.Load<Texture2D>("res://Art/varkas-skills-v25.png")):atlas;
        if(modern)cell-=40;else if(feral)cell-=25;
        int columns=modern?4:5;
        var cellSize=texture.GetSize()/new Vector2(columns,feral?1:modern?4:5);
        var center=new Vector2(Size.X/2,Passive?51:44);float radius=31;
        DrawCircle(center,radius+5,new Color("090f1b"));
        var points=new Vector2[64];var uv=new Vector2[64];
        for(int i=0;i<64;i++){
            var d=new Vector2(Mathf.Cos(i*Mathf.Tau/64),Mathf.Sin(i*Mathf.Tau/64));points[i]=center+d*radius;
            uv[i]=(new Vector2(cell%columns,feral?0:cell/columns)*cellSize+cellSize/2+d*cellSize*(feral?new Vector2(.455f,.34f):new Vector2(.455f,.455f)))/texture.GetSize();
        }
        DrawPolygon(points,new[]{Disabled?new Color(.35f,.35f,.42f):Colors.White},uv,texture);
        var gold=IsHovered()&&!Disabled?EnigmaStyle.Ivory:EnigmaStyle.Gold;
        DrawArc(center,radius+2,0,Mathf.Tau,64,gold,2,true);DrawArc(center,radius+5,0,Mathf.Tau,64,new Color(gold,.55f),1,true);
        foreach(float a in new[]{0f,Mathf.Pi/2,Mathf.Pi,Mathf.Pi*1.5f}){
            var d=new Vector2(Mathf.Cos(a),Mathf.Sin(a));var side=new Vector2(-d.Y,d.X);var tip=center+d*(radius+4);
            DrawColoredPolygon(new[]{tip+d*6,tip+side*3,tip-d*5,tip-side*3},gold);
        }
        if(Passive){DrawString(EnigmaStyle.Font,new Vector2(0,12),"Passiva",HorizontalAlignment.Center,Size.X,11,EnigmaStyle.Ivory);return;}
        if(Ability.Cooldown>0){DrawCircle(center+new Vector2(25,-23),10,new Color("0b1423"));DrawString(EnigmaStyle.Font,center+new Vector2(19,-19),Ability.Cooldown.ToString(),fontSize:12,modulate:EnigmaStyle.Ivory);}
    }
}
