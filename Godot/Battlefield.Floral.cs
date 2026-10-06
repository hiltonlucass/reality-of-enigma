using Godot;
using System;
public partial class Battlefield
{
    private void DrawFloralPower(float age){
        if(Battle?.LastSkill is not {} skill||actor==null||age<.15||age>1.85)return;
        float fade=Mathf.Clamp((1.85f-age)/.4f,0,1);
        foreach(var target in Battle.AlliedTargets){
            var at=CellFoot(true,target.Column,target.Layer);
            if(skill.Operator=="floral_thorns"||skill.Operator=="floral_basic"){
                if(target!=Battle.LastTarget)continue;
                var start=CellFoot(false,actor.Column,actor.Layer)-new Vector2(0,100);
                float reach=Mathf.Clamp((age-.2f)/.45f,0,1);
                var end=start.Lerp(at-new Vector2(0,55),reach);
                for(int n=0;n<3;n++){var offset=new Vector2(0,(n-1)*13);DrawLine(start+offset,end+offset,new Color(.46f,.08f,.32f,fade),6,true);DrawLine(start+offset,end+offset,new Color(.94f,.29f,.63f,fade),1,true);}
            }else{
                var color=skill.Operator=="floral_sleep"?new Color("cb95ed"):new Color("f0916d");
                for(int i=0;i<16;i++){
                    float t=(age*.7f+i*.13f)%1;var pos=at+new Vector2(Mathf.Sin(i*2.3f+t*4)*62,-150+t*155);
                    DrawSetTransform(pos,t*4);
                    DrawEllipse(Vector2.Zero,new Vector2(3,9),new Color(color,fade*Mathf.Sin(t*Mathf.Pi)));
                    DrawSetTransform(Vector2.Zero);
                }
                DrawEllipse(at,new Vector2(60,12),new Color(.55f,.13f,.33f,.18f*fade));
            }
        }
    }
}
