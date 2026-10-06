using Godot;
using Vaelorn;
using System;
using System.Linq;

public partial class Main
{
    private async System.Threading.Tasks.Task CaptureStatesQa(string file)
    {
        for(int n=72;n<=100;n++)if(Battlefield.UpperBodyWeight(n/100f)!=0)throw new Exception("QA pés devem permanecer fixos");
        auto=false;training=null;mode="demo";preparing=false;
        var brakk=game.Catalog.Hero("brakk");
        var caster=new Unit(brakk with {Stats=brakk.Stats with {Speed=300}},70);
        var dummy=game.Catalog.Hero("enemy_fenda") with {Stats=new Stats(30000,1,1,0,1)};
        var targets=Enumerable.Range(0,3).Select(n=>new Unit(dummy,1,false,n,0)).ToArray();
        targets[0].ApplyIce(5);targets[1].ApplyStun(2);
        battle=new Battle(game.Catalog,new[]{caster},targets);field.Bind(battle);Refresh();
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-states.png");
        for(int n=0;n<40;n++)if(Battlefield.PoseFrame(true,true,true,n*.05,.02,0,n*.1)!=0)throw new Exception("QA gelo alterou pose ao receber impacto");
        var hp=battle.Allies.Concat(battle.Enemies).ToDictionary(u=>u,u=>u.Hp);
        if(!battle.TryAct("quake",targets[0],out var error))throw new Exception(error);
        if(battle.LastImpacts.Select(i=>i.Target).Distinct().Count()!=3)throw new Exception("QA golpe não atingiu toda a fileira");
        field.Animate(hp);Refresh();
        await ToSignal(GetTree().CreateTimer(.73),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-row.png");
        await ToSignal(GetTree().CreateTimer(1.1),SceneTreeTimer.SignalName.Timeout);
        // A fresh lethal row attack exercises ice shattering without turn expiry consuming Freeze.
        caster=new Unit(brakk with {Stats=brakk.Stats with {Speed=300}},70);
        targets=Enumerable.Range(0,3).Select(n=>new Unit(dummy,1,false,n,0)).ToArray();
        targets[0].ApplyIce(5);targets[0].Hp=1;
        battle=new Battle(game.Catalog,new[]{caster},targets);field.Bind(battle);
        hp=battle.Allies.Concat(battle.Enemies).ToDictionary(u=>u,u=>u.Hp);
        if(!battle.TryAct("quake",targets[0],out error))throw new Exception(error);
        if(targets[0].Alive||targets[0].Freeze==0)throw new Exception("QA derrota congelada");
        field.Animate(hp);Refresh();
        await ToSignal(GetTree().CreateTimer(.86),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-shatter.png");
        await ToSignal(GetTree().CreateTimer(1.2),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-shards.png");
        GD.Print("QA_PLANTED_FEET_OK QA_FROZEN_HIT_POSE_LOCK_OK STUN_POSE_OK ROW_3_TARGETS_OK FROZEN_SHATTER_OK");
    }
}
