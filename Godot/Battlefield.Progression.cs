using Godot;
using Vaelorn;
using System;
using System.Collections.Generic;
public partial class Battlefield
{
    private double exitAt=-100;
    public bool ExitActive=>clock-exitAt<2;
    public float ExitProgress=>Mathf.SmoothStep(0,1,Mathf.Clamp((float)(clock-exitAt)/2,0,1));
    public void BeginExit(){exitAt=clock;}
    private readonly Dictionary<Unit,(int Gate,int Level,double At)> evolutions=new();
    private AudioStreamPlayer? evolutionAudio;private readonly HashSet<(Unit,double)> evolutionPlayed=new();
    private void DrawEvolutionAura(Unit unit,Vector2 foot){
        if(!evolutions.TryGetValue(unit,out var state)){evolutions[unit]=(unit.Gate,unit.Level,-100);return;}
        if(state.Gate!=unit.Gate||state.Level!=unit.Level){state=(unit.Gate,unit.Level,clock+HitMoment);evolutions[unit]=state;}
        float t=(float)(clock-state.At);if(t<0||t>1.8f)return;
        if(evolutionPlayed.Add((unit,state.At))){evolutionAudio??=CreateEvolutionPlayer();if(!evolutionAudio.Playing)evolutionAudio.Play();}
        var color=new Color(.75f,.45f,1,Mathf.Sin(t/1.8f*Mathf.Pi));
        for(int i=0;i<18;i++){
            float life=(t*.7f+i/18f)%1;var pos=foot+new Vector2(Mathf.Sin(i*3.7f)*43,-life*160);
            DrawLine(pos,pos+new Vector2(0,16),new Color(color,Mathf.Sin(life*Mathf.Pi)*color.A),2,true);
        }
        DrawEllipse(foot,new Vector2(48,12),new Color(color,.25f*color.A));
        Text("EVOLUIU",foot+new Vector2(-43,-135-t*15),new Color(1,.92f,1,color.A),18);
    }
    private AudioStreamPlayer CreateEvolutionPlayer(){
        var player=new AudioStreamPlayer{VolumeDb=-10};const int rate=44100;var bytes=new byte[rate*2];double[] notes={523.25,659.25,783.99,1046.5};
        for(int n=0;n<rate;n++){
            double t=n/(double)rate,value=0;
            for(int k=0;k<4;k++){double age=t-k*.105;if(age>=0)value+=(Math.Sin(Math.Tau*notes[k]*age)+.25*Math.Sin(Math.Tau*notes[k]*2*age))*Math.Exp(-age*6)*Math.Min(1,age/.006)*.18;}
            short sample=(short)(Math.Clamp(value,-1,1)*26000);bytes[2*n]=(byte)sample;bytes[2*n+1]=(byte)(sample>>8);
        }
        player.Stream=new AudioStreamWav{Format=AudioStreamWav.FormatEnum.Format16Bits,MixRate=rate,Data=bytes};AddChild(player);return player;
    }
}
