using Godot;
using System;
public partial class Battlefield
{
    private bool forestEnvironment;
    private double entranceAt=-10,endingAt=-10;
    public bool ForestEnvironment=>forestEnvironment;
    public bool EntranceActive=>clock-entranceAt<2.8;
    public void SetForest(bool forest){forestEnvironment=forest;arena=GD.Load<Texture2D>(forest?"res://Art/forest-v22.png":"res://Art/arena-v17.png");QueueRedraw();}
    public void BeginEntrance(){entranceAt=clock;clashPlayed=false;PlayCue("new-battle",1,-17);QueueRedraw();}
    public void CancelEntrance(){entranceAt=-10;}
    private void DrawEncounterTransition(){
        if(Battle==null||ExitActive)return;
        bool end=Battle.Finished&&clock-actionAt>=EffectDuration;
        if(end&&endingAt<0)endingAt=clock;
        if(EntranceActive){DrawClashEntrance();return;}
        if(!end)return;
        float t=(float)(clock-(end?endingAt:entranceAt));
        float reveal=Mathf.SmoothStep(0,1,Mathf.Clamp(t/.42f,0,1));
        float opacity=end?1:1-Mathf.SmoothStep(0,1,Mathf.Clamp((t-.8f)/.55f,0,1));
        string label=end?(Battle.Won?"VITÓRIA":"DERROTA"):"AO COMBATE";
        var tint=end&&!Battle.Won?new Color("ef8291"):gold;
        float y=Size.Y*.19f;
        float crestSize=160+15*reveal;
        // The emblem belongs to a suspended medallion, rather than appearing planted in the air.
        var medallion=new Vector2(Size.X/2,y);
        DrawCircle(medallion,crestSize*.53f,new Color(.065f,.025f,.10f,.9f));
        DrawArc(medallion,crestSize*.53f,0,Mathf.Tau,72,new Color("967444"),2,true);
        DrawArc(medallion,crestSize*.48f,0,Mathf.Tau,72,new Color("513264"),1,true);
        EnigmaIdentity.Icon(this,5,new Rect2(Size.X/2-crestSize*.42f,y-crestSize*.42f,crestSize*.84f,crestSize*.84f),new Color(1,1,1,opacity));
        int fontSize=32;var width=EnigmaIdentity.Heading.GetStringSize(label,fontSize:fontSize).X;
        var baseline=new Vector2((Size.X-width)/2,y+crestSize*.57f);
        DrawStringOutline(EnigmaIdentity.Heading,baseline,label,fontSize:fontSize,size:6,modulate:new Color("180c27"));
        DrawString(EnigmaIdentity.Heading,baseline,label,fontSize:fontSize,modulate:new Color(tint,opacity));
        if(end&&t<1.6)for(int i=0;i<18;i++){
            float angle=i*Mathf.Tau/18;var pos=new Vector2(Size.X/2,y)+new Vector2(Mathf.Cos(angle),Mathf.Sin(angle)*.4f)*(40+t*150);
            DrawCircle(pos,2,new Color(tint,(1-t/1.6f)*.8f));
        }
    }
}
