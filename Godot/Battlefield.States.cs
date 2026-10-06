using Godot;
using Vaelorn;
using System;
using System.Linq;

public partial class Battlefield
{
    private void DrawFrozenShell(Vector2 foot,float height)
    {
        // Fine crystals drift out from the silhouette; no cage or opaque ice overlay.
        for(int n=0;n<36;n++){
            float life=((float)clock*(.32f+n%4*.055f)+n*.618034f)%1;
            float side=n%2==0?1:-1;
            var origin=foot+new Vector2(Mathf.Sin(n*7.13f)*36,-height*(.18f+(n%11)*.07f));
            var pos=origin+new Vector2(side*life*(7+n%5*2),life*life*23);
            float alpha=Mathf.Sin(life*Mathf.Pi)*(.35f+n%3*.16f);
            float radius=1.1f+n%3*.55f;
            var diamond=new[]{pos+new Vector2(0,-radius*1.7f),pos+new Vector2(radius,0),pos+new Vector2(0,radius*1.7f),pos-new Vector2(radius,0)};
            DrawColoredPolygon(diamond,new Color(.65f,.9f,1,alpha));
            if(n%6==0){
                float glint=Mathf.Pow(Mathf.Max(0,Mathf.Sin(life*Mathf.Pi)),12);
                DrawLine(pos-new Vector2(3,0),pos+new Vector2(3,0),new Color(.9f,1,1,glint*.7f),1);
                DrawLine(pos-new Vector2(0,3),pos+new Vector2(0,3),new Color(.9f,1,1,glint*.7f),1);
            }
        }
    }

    private void DrawIceShatter(Vector2 foot,float height,float age)
    {
        if(age<0)return;
        float t=Mathf.Min(age,1.1f);
        if(age<.22f)Glow(foot-new Vector2(0,height*.5f),blue,95,1-age/.22f);
        for(int n=0;n<25;n++){
            float angle=n*2.39996f;
            var start=foot+new Vector2(Mathf.Sin(n*7)*27,-height*(.15f+(n%7)*.12f));
            var velocity=new Vector2(Mathf.Cos(angle)*(45+n%5*21),-35-n%6*18);
            var pos=start+velocity*t+new Vector2(0,190*t*t);
            pos.Y=Mathf.Min(pos.Y,foot.Y+5+n%4*2);
            float alpha=age<1.1f?1:Mathf.Max(.3f,1-(age-1.1f)*.7f);
            Crystal(pos,age<1.1f?10+n%4*5:5+n%3,angle+t*3,alpha);
        }
    }
    private void DrawRowTrail(Unit target,float after,float fade)
    {
        bool side=Battle!.Allies.Contains(target);
        var start=CellFoot(side,0,target.Layer)-new Vector2(0,38);
        var end=CellFoot(side,2,target.Layer)+new Vector2(0,32);
        // The full affected row remains visible, including unoccupied formation cells.
        var path=Enumerable.Range(0,25).Select(n=>start.Lerp(end,n/24f)+new Vector2(Mathf.Sin(n*2.1f)*9,0)).ToArray();
        Ribbon(path,27,new Color(.98f,.43f,.12f,.20f*fade));
        Ribbon(path,7,new Color(1,.65f,.22f,.85f*fade));
        DrawPolyline(path,new Color(1,.92f,.64f,fade),2,true);
        for(int n=0;n<12;n++){
            var center=start.Lerp(end,n/11f);
            float ripple=Mathf.Clamp(after*2.8f-n*.035f,0,1);
            var edge=center+new Vector2((n%2==0?1:-1)*(20+ripple*44),-8);
            DrawLine(center,edge,new Color(.98f,.70f,.35f,fade*.65f),2,true);
            Sparks(center,new Color("ffe3a0"),after-n*.014f,5,45);
        }
    }
}
