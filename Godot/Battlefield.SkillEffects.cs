using Godot;
using System;
using System.Linq;

public partial class Battlefield
{
    private void SlashArc(Vector2 center,float time,Color color,float rotation,float radius=80)
    {
        if(time<0||time>.42f)return;
        float t=time/.42f,alpha=Mathf.Pow(1-t,1.6f);
        float head=-2.3f+t*3.8f,tail=head-(.8f+Mathf.Sin(t*Mathf.Pi)*1.9f);
        Vector2[] Curve(float scale)=>Enumerable.Range(0,32).Select(n=>{
            float a=Mathf.Lerp(tail,head,n/31f);
            return center+new Vector2(Mathf.Cos(a)*radius*scale,Mathf.Sin(a)*radius*.43f*scale).Rotated(rotation);
        }).ToArray();
        Ribbon(Curve(1),14*(1-t),new Color(color,alpha*.18f));
        Ribbon(Curve(1),5*(1-t),new Color(color,alpha*.9f));
        Ribbon(Curve(.98f),1.5f,new Color(1,1,1,alpha));
        Sparks(center,color,time*2.1f,9,radius);
    }
    private void ImpactBloom(Vector2 center,float time,Color color,float radius=65)
    {
        if(time<0||time>.52f)return;
        float t=time/.52f,alpha=(1-t)*(1-t),r=radius*(.12f+.88f*(1-Mathf.Pow(1-t,3)));
        DrawArc(center,r,0,Mathf.Tau,56,new Color(color,alpha*.75f),2,true);
        Glow(center,color,r*.8f,alpha);
        if(time<.10f){
            float flash=1-time/.10f;
            DrawLine(center-new Vector2(radius*.7f,0),center+new Vector2(radius*.7f,0),new Color(1,1,1,flash),3,true);
            DrawLine(center-new Vector2(0,radius*.4f),center+new Vector2(0,radius*.4f),new Color(1,1,1,flash),2,true);
        }
        Sparks(center,color,time*1.7f,14,radius*1.4f);
    }
    private void DrawSkillIntroduction()
    {
        float age=(float)(clock-actionAt);
        if(actor==null||Battle?.LastSkill is not {Cooldown: >0} skill||age<0||age>.58f)return;
        float opacity=Mathf.Min(1,age/.10f)*Mathf.Clamp((.58f-age)/.12f,0,1);
        var color=PowerColor(actor);
        DrawRect(new Rect2(0,45,Size.X,Size.Y-45),new Color(.015f,.025f,.06f,opacity*.17f));
        var origin=new Vector2(85-24*(1-Mathf.Min(1,age/.15f)),Size.Y-115);
        DrawColoredPolygon(new[]{origin,origin+new Vector2(370,0),origin+new Vector2(340,91),origin+new Vector2(0,91)},new Color(.025f,.045f,.08f,opacity*.93f));
        DrawLine(origin,origin+new Vector2(370,0),new Color(color,opacity),2,true);
        if(Portrait(actor,out var texture,out var crop))DrawTextureRectRegion(texture,new Rect2(origin+new Vector2(4,-14),new Vector2(85,104)),crop,new Color(1,1,1,opacity));
        Text(actor.Definition.Name,origin+new Vector2(104,29),new Color(color,opacity),18);
        Text(skill.Name,origin+new Vector2(104,57),new Color(1,1,1,opacity),16);
    }
}
