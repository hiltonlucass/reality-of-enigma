using Godot;
using System;

// Painted banners have camera drift, subtle upper-body deformation and elemental particles.
// This is not a skeletal/Live2D character rig.
public partial class HeroBanner:Control
{
    public int HeroIndex;
    public bool Animate=true;
    public bool PortraitOnly;
    private Texture2D art=null!;private Texture2D? feral,sevrin;
    private double clock;
    public static Rect2 Region(Texture2D texture,int index,bool portrait=false){
        if(index==6)return portrait?new Rect2(texture.GetSize()*new Vector2(.25f,.04f),texture.GetSize()*new Vector2(.5f,.32f)):new Rect2(Vector2.Zero,texture.GetSize());
        if(index==5)return portrait?new Rect2(texture.GetSize()*new Vector2(.32f,.09f),texture.GetSize()*new Vector2(.48f,.32f)):new Rect2(Vector2.Zero,texture.GetSize());
        var cell=texture.GetSize()/new Vector2(5,1);
        return portrait?new Rect2(index*cell.X+cell.X*.10f,cell.Y*.045f,cell.X*.8f,cell.Y*.4f):new Rect2(index*cell.X,0,cell.X,cell.Y);
    }
    public override void _Ready(){art=GD.Load<Texture2D>("res://Art/hero-banners-v23.png");MouseFilter=MouseFilterEnum.Ignore;ClipContents=true;}
    public override void _Process(double delta){if(Animate)clock+=delta;QueueRedraw();}
    public override void _Draw(){
        if(art==null)return;
        var texture=HeroIndex==6?(sevrin??=GD.Load<Texture2D>("res://Art/sevrin-portrait-v30.png")):HeroIndex==5?(feral??=GD.Load<Texture2D>("res://Art/fenrath-portrait-v30.png")):art;
        var source=Region(texture,HeroIndex,PortraitOnly);
        float scale=PortraitOnly?Mathf.Max(Size.X/source.Size.X,Size.Y/source.Size.Y):Mathf.Min(Size.X/source.Size.X,Size.Y/source.Size.Y);
        var target=source.Size*scale*(Animate?1.02f:1);
        var origin=(Size-target)/2;
        if(Animate)origin.X+=Mathf.Sin((float)clock*.32f)*3;
        for(int n=0;n<32;n++){
            float a=n/32f,b=(n+1)/32f;
            float drift=Animate?Mathf.Sin((float)clock*1.4f)*Mathf.Sin(a*Mathf.Pi)*1.4f:0;
            DrawTextureRectRegion(texture,new Rect2(origin+new Vector2(drift,target.Y*a),new Vector2(target.X,target.Y/32+1)),new Rect2(source.Position+new Vector2(0,source.Size.Y*a),new Vector2(source.Size.X,source.Size.Y/32)));
        }
        if(Animate)for(int i=0;i<20;i++){
            float life=((float)clock*.08f+i*.137f)%1;
            var at=new Vector2((i*91)%Mathf.Max(1,Size.X),Size.Y*(1-life));
            var color=new Color(HeroIndex==4?"a4eaff":HeroIndex==3?"ffad58":"b5ebd9");
            DrawCircle(at,1+i%2,new Color(color,Mathf.Sin(life*Mathf.Pi)*.5f));
        }
    }
}
