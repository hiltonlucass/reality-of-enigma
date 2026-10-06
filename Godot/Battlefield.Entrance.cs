using Godot;
using System;
public partial class Battlefield
{
    private bool clashPlayed;
    private AudioStreamPlayer? clashAudio;
    public int ClashesPlayed{get;private set;}
    private Vector2 EntrancePosition(bool friendly,int column,int layer,Vector2 home){
        float t=(float)(clock-entranceAt);float direction=friendly?1:-1;
        var start=home-new Vector2(direction*Size.X*.62f,0);
        var center=new Vector2(Size.X*(friendly?.465f-layer*.075f:.535f+layer*.075f),home.Y);
        if(t<1.1f)return start.Lerp(center,Mathf.SmoothStep(0,1,t/1.1f));
        if(t<1.5f)return center-new Vector2(direction*Mathf.Sin((t-1.1f)/.4f*Mathf.Pi)*12,0);
        return center.Lerp(home,Mathf.SmoothStep(0,1,(t-1.5f)/1.3f));
    }
    private void UpdateClashAudio(){
        if(!EntranceActive||clashPlayed||clock-entranceAt<1.1)return;
        clashPlayed=true;ClashesPlayed++;
        PlayCue("clash",1,-14);
        soundEvents.Add((clock+.42,"spin",1,-18));
        soundEvents.Add((clock+1.55,"land",1,-18));
    }
    // Original synthesized steel impact; no audio sampled from another game.
    private static AudioStreamWav MakeClash(){
        const int rate=44100;int count=(int)(rate*.85);var bytes=new byte[count*2];var rng=new Random(724);
        for(int n=0;n<count;n++){
            double t=n/(double)rate;double value=0;
            foreach(double hz in new[]{1173d,1859d,2911d,4349d,6101d})value+=Math.Sin(Math.Tau*hz*t)*Math.Exp(-t*(5+hz/2400))*.12;
            value+=(rng.NextDouble()*2-1)*Math.Exp(-t*50)*.45;
            value*=Math.Min(1,t/.002);short sample=(short)(Math.Clamp(value,-1,1)*24000);bytes[n*2]=(byte)(sample&255);bytes[n*2+1]=(byte)(sample>>8);
        }
        return new AudioStreamWav{Format=AudioStreamWav.FormatEnum.Format16Bits,MixRate=rate,Stereo=false,Data=bytes};
    }
    private void DrawClashEntrance(){
        float t=(float)(clock-entranceAt);
        float bars=Mathf.Min(1,t/.25f)*(1-Mathf.Clamp((t-2.3f)/.5f,0,1));
        DrawRect(new Rect2(0,0,Size.X,42*bars),new Color(0,0,0,.85f));DrawRect(new Rect2(0,Size.Y-42*bars,Size.X,42*bars),new Color(0,0,0,.85f));
        if(t>1.08f&&t<1.6f){
            float age=t-1.08f;var center=new Vector2(Size.X*.5f,Size.Y*.47f);
            EnigmaStyle.Sword(this,center,-.65f,80,EnigmaStyle.Ivory);EnigmaStyle.Sword(this,center,.65f,80,EnigmaStyle.Ivory);
            for(int i=0;i<26;i++){
                float a=i*Mathf.Tau/26;var d=new Vector2(Mathf.Cos(a),Mathf.Sin(a));
                DrawLine(center+d*(15+age*120),center+d*(30+age*230),new Color(EnigmaStyle.Ivory,1-age/.52f),2,true);
            }
            DrawRect(new Rect2(Vector2.Zero,Size),new Color(1,.86f,.57f,Mathf.Max(0,.20f-age*2)));
        }
        string label=t<1.5f?"DESTINOS EM CONFRONTO":"PREPARE SUA FORMAÇÃO";
        DrawString(Font,new Vector2(0,Size.Y-13),label,HorizontalAlignment.Center,Size.X,18,EnigmaStyle.Ivory);
    }
}
