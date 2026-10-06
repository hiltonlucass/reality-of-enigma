using Godot;
using Vaelorn;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class Main
{
    private async void CaptureV26Qa(){
        try{
            var args=OS.GetCmdlineUserArgs();string file=args[Array.IndexOf(args,"--qa-v26")+1];
            IEnumerable<Node> Walk(Node n){foreach(var c in n.GetChildren()){yield return c;foreach(var x in Walk(c))yield return x;}}
            async System.Threading.Tasks.Task Capture(string suffix){await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+suffix+".png");}
            ShowHomeMenu();await Capture("-home");
            if(Walk(menuOverlay!).OfType<Label>().Any(l=>l.Text.Contains("/70"))||!Walk(menuOverlay!).OfType<GoldPouch>().Any())throw new Exception("QA menu currency/progress");
            var carousel=Walk(menuOverlay!).OfType<MenuCarousel>().Single();
            foreach(int i in new[]{4,5}){carousel.ShowHero(i);await ToSignal(GetTree().CreateTimer(1.4),SceneTreeTimer.SignalName.Timeout);await Capture("-menu-"+i);}
            Start("demo");Refresh();await Capture("-actor");
            if(skillDescription.Text.Contains("VEZ DE"))throw new Exception("QA actor portrait");
            ChooseSkillTarget(game.Catalog.Ability("rush"));var enemy=battle!.Enemies.Last(u=>u.Alive);field.SelectUnit(enemy);await Capture("-attack-target");
            if(field.TargetIntent!="attack"||!field.IsHighlightedTarget(enemy)||field.TooltipText!="")throw new Exception("QA attack marker/tooltip");
            int sounds=field.AttackSoundsPlayed;pendingSkill=null;PlayAction("rush");await ToSignal(GetTree().CreateTimer(1.9),SceneTreeTimer.SignalName.Timeout);
            if(field.AttackSoundsPlayed<=sounds)throw new Exception("QA attack sound");
            if(field.RecordedSoundsPlayed==0)throw new Exception("QA recorded MP3 playback");
            foreach(string id in new[]{"aelia","savor"}){
                var definition=game.Catalog.Hero(id);var hero=new Unit(definition with{Stats=definition.Stats with{Speed=400}},30);var ally=new Unit(game.Catalog.Hero("kael"),30,false,1,0);ally.Hp*=.5;
                var foe=game.Catalog.Hero("enemy_fenda");battle=new Battle(game.Catalog,new[]{hero,ally},new[]{new Unit(foe with{Stats=foe.Stats with{Hp=20000}},1,true)});
                field.Bind(battle);pendingSkill=null;preparing=false;Refresh();
                var skill=battle.SkillsFor(hero).First(s=>s.Operator==(id=="aelia"?"heal":"buff"));ChooseSkillTarget(skill);field.SelectUnit(ally);await Capture("-"+id+"-support");
                if(field.TargetIntent!=(id=="aelia"?"heal":"support")||!field.IsHighlightedTarget(ally)||field.IsHighlightedTarget(battle.Enemies[0]))throw new Exception("QA support target marker");
                pendingSkill=null;PlayAction(skill.Id);await ToSignal(GetTree().CreateTimer(1.9),SceneTreeTimer.SignalName.Timeout);
                if(field.BuffDescription(ally).Contains("+0%")||field.TooltipText.Contains("comida"))throw new Exception("QA zero buff detail");
            }
            Start("story");preparing=true;field.FormationEditing=false;field.BeginEntrance();Refresh();int steps=field.FootstepsPlayed;
            await ToSignal(GetTree().CreateTimer(1.34),SceneTreeTimer.SignalName.Timeout);
            for(int i=0;i<7;i++){await Capture("-retreat-"+i);await ToSignal(GetTree().CreateTimer(.135),SceneTreeTimer.SignalName.Timeout);}
            await ToSignal(GetTree().CreateTimer(.3),SceneTreeTimer.SignalName.Timeout);await Capture("-landed");
            if(field.EntranceActive||field.FootstepsPlayed<=steps)throw new Exception("QA entry/footsteps");
            if(Enumerable.Range(0,101).Select(i=>Battlefield.RetreatFrame(i/100f)).Distinct().Count()!=8)throw new Exception("QA eight retreat poses");
            var cast=new[]{"lyra","varkhan","varkas"}.Select((id,i)=>new Unit(game.Catalog.Hero(id),30,false,i,0)).ToArray();
            battle=new Battle(game.Catalog,cast,new[]{new Unit(game.Catalog.Hero("solarius"),70,true)});
            field.Bind(battle);preparing=true;field.FormationEditing=false;field.BeginEntrance();Refresh();
            await ToSignal(GetTree().CreateTimer(1.9),SceneTreeTimer.SignalName.Timeout);await Capture("-extra-cast-retreat");
            await ToSignal(GetTree().CreateTimer(1),SceneTreeTimer.SignalName.Timeout);
            battle.Enemies[0].AddStatus(game.Catalog.StatusEffects.Single(s=>s.Id=="bleed"),cast[2]);
            battle.Enemies[0].AddStatus(game.Catalog.StatusEffects.Single(s=>s.Id=="bleed"),cast[2]);
            await Capture("-bleeding");
            game.Save.CompletedStage=0;game.Save.OpeningSeen=true;game.Save.ForestEncounterSeen=true;foreach(var owned in game.Save.Roster){owned.Level=70;owned.Stars=6;}StartCampaignStage(1);
            for(int n=0;n<400&&!battle!.Finished;n++)Step();await ToSignal(GetTree().CreateTimer(2),SceneTreeTimer.SignalName.Timeout);await Capture("-victory");
            var next=Walk(menuOverlay!).OfType<JourneyArrow>().Single(b=>!b.Back);var back=Walk(menuOverlay!).OfType<JourneyArrow>().Single(b=>b.Back);
            if(next.GetGlobalRect().Position.X<GetViewportRect().Size.X*.8||back.GetGlobalRect().Position.Y>GetViewportRect().Size.Y*.3)throw new Exception("QA result placement");
            steps=field.FootstepsPlayed;next.EmitSignal(BaseButton.SignalName.Pressed);await ToSignal(GetTree().CreateTimer(.7),SceneTreeTimer.SignalName.Timeout);await Capture("-walk");
            if(field.FootstepsPlayed<=steps)throw new Exception("QA walking sound");
            await ToSignal(GetTree().CreateTimer(1.3),SceneTreeTimer.SignalName.Timeout);if(encounterStage!=2)throw new Exception("QA stage transition");
            ShowCampaignMenu();await Capture("-map");
            GD.Print("QA_V26_MENU_POUCH_PORTRAIT_ATTACK_HEAL_BUFF_TARGETS_MINIMAL_BUFFS_8_POSES_AUDIO_VICTORY_ARROW_NEXT_OK");GetTree().Quit();
        }catch(Exception e){GD.PrintErr(e);GetTree().Quit(1);}
    }
}
