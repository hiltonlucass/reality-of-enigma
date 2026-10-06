using Godot;
using Vaelorn;
using System;
using System.Linq;

public partial class Main
{
    private async System.Threading.Tasks.Task CaptureFormationQa(string file)
    {
        auto=false;training=null;mode="demo";
        var heroes=new[]{"kael","savor","aelia","brakk","lyra"}.Select((id,i)=>new Unit(game.Catalog.Hero(id),20,false,i%3,i/3)).ToArray();
        var target=new Unit(game.Catalog.Hero("varkhan") with {Stats=new Stats(30000,1,1,0,1)},20,true,0,2);
        battle=new Battle(game.Catalog,heroes,new[]{target});field.Bind(battle);preparing=true;field.FormationEditing=true;Refresh();
        await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);
        // Exercise the same press/release path as a player's click and drag.
        var source=field.CellFoot(true,heroes[0].Column,heroes[0].Layer)-new Vector2(0,40);
        var destination=field.CellFoot(true,2,2)-new Vector2(0,40);
        field._GuiInput(new InputEventMouseButton{ButtonIndex=MouseButton.Left,Pressed=true,Position=source});
        field._GuiInput(new InputEventMouseButton{ButtonIndex=MouseButton.Left,Pressed=false,Position=destination});
        if(heroes[0].Column!=2||heroes[0].Layer!=2)throw new Exception("QA arraste 3x3");
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-formation.png");
        BeginCombat();if(battle.TryMoveAlly(heroes[0],0))throw new Exception("QA formação liberada após iniciar");
        var home=field.CellFoot(true,heroes[0].Column,heroes[0].Layer);var goal=field.CellFoot(false,target.Column,target.Layer);
        foreach(float direction in new[]{1f,-1f}){
            var contact=Battlefield.MeleePosition(home,goal,direction,.65f);
            if(Math.Abs(contact.Y-goal.Y)>.01||Math.Abs(contact.X-(goal.X-direction*82))>.01||Battlefield.MeleePosition(home,goal,direction,1.8f).DistanceTo(home)>.01)throw new Exception("QA alinhamento e retorno");
        }
        // Cross-row travel from back/top to far back/bottom, formerly clamped to 350 px.
        home=new Vector2(150,180);goal=new Vector2(1200,470);
        if(Battlefield.MeleePosition(home,goal,1,.65f).DistanceTo(new Vector2(1118,470))>.01)throw new Exception("QA percurso diagonal longo");
        var hp=battle.Allies.Concat(battle.Enemies).ToDictionary(u=>u,u=>u.Hp);
        if(!battle.TryAct("rush",target,out var error))throw new Exception(error);field.Animate(hp);Refresh();
        await ToSignal(GetTree().CreateTimer(.25),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-run.png");
        await ToSignal(GetTree().CreateTimer(.36),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-contact.png");
        await ToSignal(GetTree().CreateTimer(1.2),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-return.png");
        GD.Print("QA_FORMATION_DRAG_LOCK_3X3_OK MOTION_TARGET_ROW_RETURN_OK");
    }
}
