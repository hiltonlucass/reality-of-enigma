using Godot;
using System;

public static class EnigmaIdentity
{
    private static Texture2D? atlas;
    public static Texture2D Atlas=>atlas??=GD.Load<Texture2D>("res://Art/identity-v26.png");
    public static void Icon(CanvasItem canvas,int cell,Rect2 rect,Color? tint=null){var size=Atlas.GetSize()/new Vector2(3,2);canvas.DrawTextureRectRegion(Atlas,rect,new Rect2(new Vector2(cell%3,cell/3)*size,size),tint??Colors.White);}
    private static Font? heading;
    public static Font Heading=>heading??=new FontVariation{BaseFont=GD.Load<FontFile>("res://Art/Fonts/Cinzel.ttf"),VariationEmbolden=1.8f};
}
public partial class GoldPouch:Control
{
    public decimal Amount;
    public override void _Ready(){MouseFilter=MouseFilterEnum.Ignore;TextureFilter=TextureFilterEnum.Linear;}
    public override void _Draw(){
        DrawStyleBox(new StyleBoxFlat{BgColor=new Color(.03f,.02f,.06f,.72f),CornerRadiusTopLeft=20,CornerRadiusTopRight=20,CornerRadiusBottomLeft=20,CornerRadiusBottomRight=20},new Rect2(24,18,Size.X-30,48));
        EnigmaIdentity.Icon(this,3,new Rect2(0,0,80,80));
        DrawStringOutline(EnigmaIdentity.Heading,new Vector2(83,51),Amount.ToString("N0"),fontSize:24,size:4,modulate:new Color("130b22"));
        DrawString(EnigmaIdentity.Heading,new Vector2(83,51),Amount.ToString("N0"),fontSize:24,modulate:EnigmaStyle.Ivory);
    }
}
public partial class JourneyArrow:Button
{
    public bool Back;
    private float clock;
    public override void _Ready(){Text=Back?"Voltar":"Próxima fase";foreach(var s in new[]{"normal","hover","pressed","focus"})AddThemeStyleboxOverride(s,new StyleBoxEmpty());AddThemeColorOverride("font_color",Colors.Transparent);AddThemeColorOverride("font_hover_color",Colors.Transparent);AddThemeColorOverride("font_pressed_color",Colors.Transparent);MouseDefaultCursorShape=CursorShape.PointingHand;TextureFilter=TextureFilterEnum.Linear;}
    public override void _Process(double delta){clock+=(float)delta;QueueRedraw();}
    public override void _Draw(){
        float drift=Main.ReducedMotion?0:Mathf.Sin(clock*3)*5;
        var center=new Vector2(Size.X/2+drift,Back?23:Size.Y*.4f);float size=Back?78:145;
        DrawSetTransform(center,Back?Mathf.Pi:0);EnigmaIdentity.Icon(this,4,new Rect2(-size/2,-size/2,size,size),IsHovered()||HasFocus()?new Color(1.2f,1.1f,1.2f):Colors.White);DrawSetTransform(Vector2.Zero);
        var at=new Vector2(0,Back?60:Size.Y-12);
        DrawStringOutline(EnigmaIdentity.Heading,at,Text,HorizontalAlignment.Center,Size.X,Back?18:21,5,new Color("120921"));
        DrawString(EnigmaIdentity.Heading,at,Text,HorizontalAlignment.Center,Size.X,Back?18:21,EnigmaStyle.Ivory);
    }
}
public partial class ActingPortrait:Control
{
    public Battlefield Field=null!;
    public override void _Ready(){CustomMinimumSize=new Vector2(76,66);MouseFilter=MouseFilterEnum.Ignore;TextureFilter=TextureFilterEnum.Linear;}
    public override void _Process(double delta)=>QueueRedraw();
    public override void _Draw(){
        var unit=Field.DisplayActor;if(unit==null)return;
        var center=new Vector2(Size.X/2,33);DrawCircle(center,29,new Color("130b21"));
        DrawArc(center,29,0,Mathf.Tau,48,EnigmaStyle.Gold,2,true);
        if(Field.Portrait(unit,out var image,out var region))DrawTextureRectRegion(image,new Rect2(center-new Vector2(21,25),new Vector2(42,50)),region);
        EnigmaIdentity.Icon(this,0,new Rect2(center+new Vector2(17,-32),new Vector2(42,58)));
    }
}
