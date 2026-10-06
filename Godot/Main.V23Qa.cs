using Godot;
using Vaelorn;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class Main
{
    private async void CaptureV23Qa()
    {
        try{
            var args=OS.GetCmdlineUserArgs();string file=args[Array.IndexOf(args,"--qa-v23")+1];
            IEnumerable<Node> Walk(Node n){foreach(var c in n.GetChildren()){yield return c;foreach(var x in Walk(c))yield return x;}}
            async System.Threading.Tasks.Task Capture(string suffix){await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+suffix+".png");}
            ShowHomeMenu();await Capture("-home");
            var banner=Walk(menuOverlay!).OfType<MenuCarousel>().Single();
            foreach(int index in new[]{1,4}){banner.ShowHero(index);await Capture("-banner-"+index);}
            game.Save.CompletedStage=0;campaignRegion=0;ShowCampaignMenu();await Capture("-locked-map");
            var nodes=Walk(menuOverlay!).OfType<StageIsland>().ToArray();
            if(nodes.Length!=10||nodes.Count(n=>!n.Disabled)!=1)throw new Exception("QA bloqueio inicial de ilhas");
            var tabs=Walk(menuOverlay!).OfType<RegionTab>().ToArray();
            if(tabs.Length!=7||tabs.Count(b=>!b.Disabled)!=1)throw new Exception("QA bloqueio de cenários");
            game.Save.CompletedStage=70;
            for(int i=0;i<7;i++){campaignRegion=i;ShowCampaignMenu();await Capture("-region-"+(i+1));var boss=Walk(menuOverlay!).OfType<StageIsland>().Single(n=>n.Boss);if(!boss.Disabled)throw new Exception("QA chefe repetível no mapa");}
            ShowCharacterCards();
            if(Walk(menuOverlay!).OfType<TextureButton>().Count()!=JourneyData.Revealed.Length||Walk(menuOverlay!).OfType<OptionButton>().Any())throw new Exception("QA galeria não usa retratos revelados");
            for(int i=0;i<JourneyData.Revealed.Length;i++){
                var hero=Walk(menuOverlay!).OfType<TextureButton>().Single(b=>b.Name=="Hero_"+JourneyData.Revealed[i]);hero.EmitSignal(BaseButton.SignalName.Pressed);await Capture("-hero-"+JourneyData.Revealed[i]);
                var skills=Walk(menuOverlay!).OfType<SkillIconButton>().ToArray();if(skills.Length<3)throw new Exception("QA habilidades da ficha");
                skills.First(s=>!s.Passive).EmitSignal(BaseButton.SignalName.Pressed);
                if(!Walk(menuOverlay!).OfType<Label>().Any(l=>l.Text.StartsWith(skills.First(s=>!s.Passive).Ability.Name)))throw new Exception("QA descrição não abriu");
                skills.Single(s=>s.Passive).EmitSignal(BaseButton.SignalName.Pressed);
                if(!Walk(menuOverlay!).OfType<Label>().Any(l=>l.Text==PassiveDescription(new Unit(game.Catalog.Hero(JourneyData.Revealed[i])))))throw new Exception("QA passiva na ficha");
            }
            game.Save.CompletedStage=0;game.Save.OpeningSeen=true;game.Save.ForestEncounterSeen=true;foreach(var owned in game.Save.Roster){owned.Level=70;owned.Stars=6;}
            StartCampaignStage(1);
            for(int n=0;n<400&&!battle!.Finished;n++)Step();
            await ToSignal(GetTree().CreateTimer(2),SceneTreeTimer.SignalName.Timeout);await Capture("-result");
            if(game.Save.CompletedStage!=1||!Walk(menuOverlay!).OfType<Button>().Any(b=>b.Name=="NextStageArrow"))throw new Exception("QA próxima fase ausente");
            var gold=game.Save.Inventory.Gold;StartCampaignStage(1);
            for(int n=0;n<400&&!battle!.Finished;n++)Step();
            if(game.Save.CompletedStage!=1||game.Save.Inventory.Gold!=gold+game.Catalog.Stages.Single(s=>s.Number==1).Gold)throw new Exception("QA recompensa do replay");
            Step();if(game.Save.Inventory.Gold!=gold+game.Catalog.Stages.Single(s=>s.Number==1).Gold)throw new Exception("QA recompensa duplicada");
            game.Save.CompletedStage=9;StartCampaignStage(10);
            for(int n=0;n<400&&!battle!.Finished;n++)Step();
            await ToSignal(GetTree().CreateTimer(2),SceneTreeTimer.SignalName.Timeout);await Capture("-boss-story");
            if(game.Save.CompletedStage!=10||JourneyData.UnlockedRegion(game.Save.CompletedStage)!=1)throw new Exception("QA chefe não abriu cenário");
            var reveal=Walk(menuOverlay!).OfType<Button>().Single(b=>b.Text.StartsWith("Revelar cenário 2"));reveal.EmitSignal(BaseButton.SignalName.Pressed);await Capture("-region-unlocked");
            if(campaignRegion!=1)throw new Exception("QA revelação do cenário");
            GD.Print("QA_V23_7_MAPS_LOCKS_5_HEROES_SKILL_DETAILS_REPLAY_REWARD_NEXT_STAGE_BOSS_STORY_OK");GetTree().Quit();
        }catch(Exception e){GD.PrintErr(e);GetTree().Quit(1);}
    }
}
