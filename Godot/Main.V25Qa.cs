using Godot;
using Vaelorn;
using System;
using System.Linq;
using System.Collections.Generic;
public partial class Main
{
    private async void CaptureV25Qa(){
        try{
            var args=OS.GetCmdlineUserArgs();string file=args[Array.IndexOf(args,"--qa-v25")+1];
            IEnumerable<Node> Walk(Node n){foreach(var c in n.GetChildren()){yield return c;foreach(var x in Walk(c))yield return x;}}
            async System.Threading.Tasks.Task Capture(string suffix){await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+suffix+".png");}
            ShowHomeMenu();await Capture("-home");Start("varkas");await Capture("-varkas");
            var v=battle!.Allies[0];PlayAction("duality");await ToSignal(GetTree().CreateTimer(2),SceneTreeTimer.SignalName.Timeout);await Capture("-duality");
            if(battle.Allies.Count!=2||battle.AlliedTargets.Count!=3||v.Duality==null)throw new Exception("QA split targets");
            var spirit=v.Duality.Spirit;field.SelectUnit(spirit);if(field.Selected!=spirit)throw new Exception("QA spirit targeting");
            for(int n=0;n<10&&battle.NextActor!=v;n++)Step();
            await ToSignal(GetTree().CreateTimer(2),SceneTreeTimer.SignalName.Timeout);ChooseSkillTarget(game.Catalog.Ability("gale_fangs"));await Capture("-skill");PlayAction("gale_fangs");
            if(battle.LastImpacts.Count!=10)throw new Exception("QA copied attacks");
            await ToSignal(GetTree().CreateTimer(.8),SceneTreeTimer.SignalName.Timeout);await Capture("-gale");
            ShowCharacterCards();var card=Walk(menuOverlay!).OfType<TextureButton>().Single(b=>b.Name=="Hero_varkas");card.EmitSignal(BaseButton.SignalName.Pressed);await Capture("-card");
            Start("story");preparing=true;field.FormationEditing=false;field.BeginEntrance();Refresh();await ToSignal(GetTree().CreateTimer(1.62),SceneTreeTimer.SignalName.Timeout);await Capture("-flip");await ToSignal(GetTree().CreateTimer(1.1),SceneTreeTimer.SignalName.Timeout);BeginCombat();await Capture("-formation");
            Start("sandbox");await Capture("-gate-base");battle!.Allies[0].Hp=battle.Allies[0].MaxHp;field.Bind(battle);await Capture("-gate-bind");
            // New lower gate allows a real stage change to trigger the aura observer.
            var martial=new Unit(game.Catalog.Hero("kael"),70,path:"martial");battle=new Battle(game.Catalog,new[]{martial},new[]{new Unit(game.Catalog.Hero("solarius"),70,true)});field.Bind(battle);Refresh();await Capture("-gate-ready");martial.OpenGate();await ToSignal(GetTree().CreateTimer(.9),SceneTreeTimer.SignalName.Timeout);await Capture("-aura");
            game.Save.CompletedStage=0;game.Save.OpeningSeen=true;game.Save.ForestEncounterSeen=true;foreach(var owned in game.Save.Roster){owned.Level=70;owned.Stars=6;}StartCampaignStage(1);
            for(int n=0;n<400&&!battle!.Finished;n++)Step();await ToSignal(GetTree().CreateTimer(2),SceneTreeTimer.SignalName.Timeout);await Capture("-victory");
            var next=Walk(menuOverlay!).OfType<Button>().Single(b=>b.Name=="NextStageArrow");next.EmitSignal(BaseButton.SignalName.Pressed);await ToSignal(GetTree().CreateTimer(.8),SceneTreeTimer.SignalName.Timeout);await Capture("-walk");
            await ToSignal(GetTree().CreateTimer(1.2),SceneTreeTimer.SignalName.Timeout);if(encounterStage!=2)throw new Exception("QA next stage walk");
            GD.Print("QA_V25_VARKAS_SPLIT_TARGETS_TEN_HITS_CARD_FLIP_AURA_FIELD_RESULT_WALK_OK");GetTree().Quit();
        }catch(Exception e){GD.PrintErr(e);GetTree().Quit(1);}
    }
}
