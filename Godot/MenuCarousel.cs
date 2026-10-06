using Godot;
using System;

public partial class MenuCarousel:Control
{
    private Texture2D[] scenes=Array.Empty<Texture2D>();
    private double clock,switched;
    private int previous;
    public int HeroIndex{get;private set;}
    private readonly Random random=new();
    public int Transitions{get;private set;}
    public void ShowHero(int index){previous=HeroIndex;HeroIndex=index;switched=clock;Transitions++;QueueRedraw();}
    public override void _Ready(){scenes=Array.ConvertAll(new[]{"kael","savor","aelia","brakk","lyra","raizen"},id=>GD.Load<Texture2D>("res://Art/menu-"+id+"-v26.png"));MouseFilter=MouseFilterEnum.Ignore;ClipContents=true;TextureFilter=TextureFilterEnum.Linear;}
    public override void _Process(double delta){clock+=delta;if(clock-switched>8)ShowHero((HeroIndex+random.Next(1,6))%6);QueueRedraw();}
    public override void _Draw(){
        if(scenes.Length==0)return;
        float blend=Main.ReducedMotion?1:Mathf.SmoothStep(0,1,Mathf.Clamp((float)(clock-switched)/1.25f,0,1));
        Paint(previous,1);Paint(HeroIndex,blend);
        for(int i=0;i<28;i++){
            float t=Main.ReducedMotion?i/28f:((float)clock*.06f+i*.131f)%1;
            var at=new Vector2((i*107)%Mathf.Max(1,Size.X),Size.Y*(1-t));DrawCircle(at,1+i%2,new Color(EnigmaStyle.Ivory,Mathf.Sin(t*Mathf.Pi)*.25f));
        }
        // Soft vignette integrates the character scene into the menu column.
        for(int i=0;i<40;i++)DrawRect(new Rect2(i*3,0,3,Size.Y),new Color(.025f,.035f,.055f,(1-i/40f)*.65f));
    }
    private void Paint(int index,float alpha){
        var art=scenes[index];var cell=art.GetSize();var source=new Rect2(Vector2.Zero,cell);
        float zoom=Main.ReducedMotion?1:1.025f+Mathf.Sin((float)clock*.22f)*.008f;
        float scale=Mathf.Max(Size.X/cell.X,Size.Y/cell.Y)*zoom;
        var target=cell*scale;var origin=new Vector2((Size.X-target.X)*.65f,(Size.Y-target.Y)*.15f);
        // Cover fills the entire panel; the authored top safe area protects the head.
        for(int n=0;n<48;n++){
            float a=n/48f;float drift=Main.ReducedMotion?0:Mathf.Sin((float)clock*1.1f)*Mathf.Sin(a*Mathf.Pi)*1.1f;
            DrawTextureRectRegion(art,new Rect2(origin+new Vector2(drift,target.Y*a),new Vector2(target.X,target.Y/48+1)),new Rect2(source.Position+new Vector2(0,cell.Y*a),new Vector2(cell.X,cell.Y/48)),new Color(1,1,1,alpha));
        }
    }
}
