using Godot;
using System;
using System.Linq;

public static class EnigmaStyle
{
    private static Font? font;
    public static Font Font=>font??=new FontVariation{BaseFont=GD.Load<FontFile>("res://Art/Fonts/Cinzel.ttf"),VariationEmbolden=.35f};
    public static readonly Color Gold=new("d5b876"),Ivory=new("fff0c7");
    public static void Frame(CanvasItem c,Rect2 r,bool bright=false){
        var p=r.Position;var s=r.Size;float k=12;var color=bright?Ivory:Gold;
        var points=new[]{p+new Vector2(k,0),p+new Vector2(s.X-k,0),p+new Vector2(s.X,k),p+new Vector2(s.X,s.Y-k),p+new Vector2(s.X-k,s.Y),p+new Vector2(k,s.Y),p+new Vector2(0,s.Y-k),p+new Vector2(0,k)};
        c.DrawColoredPolygon(points,new Color(.12f,.035f,.22f,.97f));
        c.DrawPolyline(points.Append(points[0]).ToArray(),color,1.4f,true);
        foreach(float x in new[]{p.X+16,p.X+s.X-16})foreach(float y in new[]{p.Y+7,p.Y+s.Y-7}){
            var at=new Vector2(x,y);c.DrawColoredPolygon(new[]{at+new Vector2(0,-3),at+new Vector2(7,0),at+new Vector2(0,3),at+new Vector2(-7,0)},color);
        }
        var center=p+new Vector2(s.X/2,0);c.DrawColoredPolygon(new[]{center+new Vector2(-6,0),center+new Vector2(0,-4),center+new Vector2(6,0),center+new Vector2(0,4)},color);
    }
    public static void Lock(CanvasItem c,Vector2 at,float scale=1){
        c.DrawArc(at+new Vector2(0,-5)*scale,8*scale,Mathf.Pi,Mathf.Tau,20,Gold,3*scale,true);
        c.DrawRect(new Rect2(at+new Vector2(-11,-5)*scale,new Vector2(22,19)*scale),new Color("182132"));
        c.DrawRect(new Rect2(at+new Vector2(-11,-5)*scale,new Vector2(22,19)*scale),Gold,false,2*scale);
        c.DrawCircle(at+new Vector2(0,2)*scale,2*scale,Ivory);c.DrawLine(at+new Vector2(0,3)*scale,at+new Vector2(0,8)*scale,Ivory,2*scale);
    }
    public static void Sword(CanvasItem c,Vector2 at,float angle,float size,Color color){
        var d=new Vector2(Mathf.Sin(angle),-Mathf.Cos(angle));var side=new Vector2(-d.Y,d.X);
        c.DrawColoredPolygon(new[]{at+d*size,at+d*(size*.67f)+side*3,at-d*size*.25f+side*3,at-d*size*.25f-side*3,at+d*(size*.67f)-side*3},color);
        c.DrawLine(at-d*size*.25f-side*size*.27f,at-d*size*.25f+side*size*.27f,Gold,3,true);
        c.DrawLine(at-d*size*.25f,at-d*size*.58f,Gold,4,true);
    }
}
public partial class EnigmaPanel:PanelContainer
{
    public override void _Ready(){var style=new StyleBoxEmpty{ContentMarginLeft=20,ContentMarginRight=20,ContentMarginTop=12,ContentMarginBottom=12};AddThemeStyleboxOverride("panel",style);Resized+=QueueRedraw;}
    public override void _Draw()=>EnigmaStyle.Frame(this,new Rect2(1,5,Size.X-2,Size.Y-6));
}
public partial class RegionTab:Button
{
    public int RegionIndex;public bool Current;
    private Texture2D art=null!;
    public override void _Ready(){art=GD.Load<Texture2D>(JourneyData.Regions[RegionIndex].Art);foreach(var state in new[]{"normal","hover","pressed","disabled","focus"})AddThemeStyleboxOverride(state,new StyleBoxEmpty());}
    public override void _Draw(){
        if(art==null)return;
        DrawTextureRect(art,new Rect2(4,6,Size.X-8,Size.Y-12),false,Disabled?new Color(.35f,.37f,.44f):Colors.White);
        DrawRect(new Rect2(4,Size.Y-45,Size.X-8,39),new Color(.02f,.03f,.05f,.88f));
        var border=Current||IsHovered()?EnigmaStyle.Ivory:EnigmaStyle.Gold;
        DrawRect(new Rect2(3,5,Size.X-6,Size.Y-10),border,false,Current?3:1);
        if(Disabled){
            for(int i=0;i<12;i++){
                float x=9+i*(Size.X-18)/11;
                foreach(float y in new[]{16+x*.20f,45-x*.20f}){
                    DrawSetTransform(new Vector2(x,y),i%2==0?.5f:-.5f,new Vector2(1,.55f));DrawArc(Vector2.Zero,7,0,Mathf.Tau,16,new Color("b6ad96"),2,true);DrawSetTransform(Vector2.Zero);
                }
            }
            EnigmaStyle.Lock(this,new Vector2(Size.X/2,32),1.1f);
        }
        var words=JourneyData.Regions[RegionIndex].Name.Split(' ');int split=Math.Max(1,words.Length/2);
        DrawString(EnigmaStyle.Font,new Vector2(7,Size.Y-26),string.Join(" ",words.Take(split)),HorizontalAlignment.Center,Size.X-14,12,EnigmaStyle.Ivory);
        DrawString(EnigmaStyle.Font,new Vector2(7,Size.Y-11),string.Join(" ",words.Skip(split)),HorizontalAlignment.Center,Size.X-14,12,EnigmaStyle.Ivory);
    }
}
