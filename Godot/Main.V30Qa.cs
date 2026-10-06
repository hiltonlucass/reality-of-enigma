using Godot;
using Vaelorn;
using System;
using System.Linq;
using System.Collections.Generic;
public partial class Main
{
    private async void CaptureV30Qa(){
        try{
            var args=OS.GetCmdlineUserArgs();string file=args[Array.IndexOf(args,"--qa-v30")+1];
            IEnumerable<Node> Walk(Node n){foreach(var c in n.GetChildren()){yield return c;foreach(var x in Walk(c))yield return x;}}
            async System.Threading.Tasks.Task Capture(string suffix){await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+suffix+".png");}
            ShowCharacterCards();Walk(menuOverlay!).OfType<TextureButton>().Single(b=>b.Name=="Hero_varkas").EmitSignal(BaseButton.SignalName.Pressed);await Capture("-fenrath-card");
            Start("varkas");var wolf=battle!.Allies[0];PlayAction("duality");
            await ToSignal(GetTree().CreateTimer(1.8),SceneTreeTimer.SignalName.Timeout);
            for(int i=0;i<10&&battle.NextActor!=wolf;i++)Step();
            await ToSignal(GetTree().CreateTimer(1.8),SceneTreeTimer.SignalName.Timeout);
            PlayAction("gale_fangs");
            if(battle.LastImpacts.Count!=10||battle.LastImpacts.Select(h=>h.Attacker).Distinct().Count()!=2)throw new Exception("Spiral source routing");
            await ToSignal(GetTree().CreateTimer(.42),SceneTreeTimer.SignalName.Timeout);
            for(int i=0;i<5;i++){await Capture("-spiral-"+i);await ToSignal(GetTree().CreateTimer(.40),SceneTreeTimer.SignalName.Timeout);}
            if(field.EffectDuration<3)throw new Exception("Spiral duration");
            Start("floral");await Capture("-boss");
            var flower=battle!.Enemies.Single();flower.LoseHp(flower.Hp*.76);await Capture("-boss-bloom");
            for(int i=0;i<20&&battle.NextActor!=flower;i++)Step();
            Step();await ToSignal(GetTree().CreateTimer(.65),SceneTreeTimer.SignalName.Timeout);await Capture("-boss-power");
            if(!flower.Blooming||flower.Id!="nerathis")throw new Exception("Floral phase");
            ShowCharacterCards();Walk(menuOverlay!).OfType<TextureButton>().Single(b=>b.Name=="Hero_sevrin").EmitSignal(BaseButton.SignalName.Pressed);await Capture("-sevrin-card");
            Start("sevrin");PlayAction("scarlet_ultimate");await ToSignal(GetTree().CreateTimer(.82),SceneTreeTimer.SignalName.Timeout);await Capture("-sevrin-damage");
            Start("eclipse");await Capture("-maltherion");battle!.Enemies[0].LoseHp(battle.Enemies[0].MaxHp*.51);await Capture("-maltherion-ascended");
            field.SilenceActionSounds();Hide();await ToSignal(GetTree().CreateTimer(.3),SceneTreeTimer.SignalName.Timeout);
            GD.Print("QA_V30_CARDS_SPIRALS_SCARLET_DAMAGE_TWO_BOSS_PHASES_OK");GetTree().Quit();
        }catch(Exception e){GD.PrintErr(e);GetTree().Quit(1);}
    }
}
