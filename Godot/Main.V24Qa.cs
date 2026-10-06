using Godot;
using Vaelorn;
using System;
using System.Linq;
using System.Collections.Generic;
public partial class Main
{
    private async void CaptureV24Qa(){
        try{
            var args=OS.GetCmdlineUserArgs();string file=args[Array.IndexOf(args,"--qa-v24")+1];
            IEnumerable<Node> Walk(Node n){foreach(var c in n.GetChildren()){yield return c;foreach(var x in Walk(c))yield return x;}}
            async System.Threading.Tasks.Task Capture(string suffix){await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+suffix+".png");}
            game.Save.CompletedStage=0;ShowHomeMenu();await Capture("-home");
            var labels=Walk(menuOverlay!).OfType<Button>().Select(b=>b.Text).ToArray();
            if(!labels.Contains("CONFIGURAÇÕES")||!labels.Contains("SAIR")||labels.Contains("SALA DE TREINAMENTO")||labels.Contains("REVER O PRÓLOGO")||labels.Contains("VOLTAR AO COMBATE")||Walk(menuOverlay!).OfType<TextureButton>().Any())throw new Exception("QA menu incorreto");
            var carousel=Walk(menuOverlay!).OfType<MenuCarousel>().Single();carousel.ShowHero(5);
            await ToSignal(GetTree().CreateTimer(1.4),SceneTreeTimer.SignalName.Timeout);await Capture("-raizen");
            carousel._Process(8.1);if(carousel.HeroIndex==5||carousel.Transitions!=2)throw new Exception("QA carrossel não troca ou repete imediatamente");
            ShowSettings();await Capture("-settings");
            var slider=Walk(menuOverlay!).OfType<HSlider>().Single();slider.Value=35;if(Math.Abs(masterVolume-.35f)>.01)throw new Exception("QA volume");slider.Value=70;
            ShowTrainingMenu();if(!Walk(menuOverlay!).OfType<MenuCarousel>().Any())throw new Exception("QA treino acessível antes da fase 10");
            game.Save.CompletedStage=10;ShowHomeMenu();if(!Walk(menuOverlay!).OfType<Button>().Any(b=>b.Text=="SALA DE TREINAMENTO"))throw new Exception("QA treino não abriu");
            game.Save.CompletedStage=1;campaignRegion=0;ShowCampaignMenu();await Capture("-map");
            if(Walk(menuOverlay!).OfType<RegionTab>().Count()!=7||Walk(menuOverlay!).OfType<RegionTab>().Count(b=>!b.Disabled)!=1||Walk(menuOverlay!).OfType<StageIsland>().Count(b=>b.Next)!=1)throw new Exception("QA mapa e bloqueios");
            game.Save.CompletedStage=70;
            for(int i=1;i<7;i++){campaignRegion=i;ShowCampaignMenu();await Capture("-region-"+(i+1));}
            game.Save.CompletedStage=1;game.Save.OpeningSeen=true;game.Save.ForestEncounterSeen=true;StartCampaignStage(2);preparing=true;field.FormationEditing=false;field.BeginEntrance();Refresh();
            var hp=battle!.Allies.Concat(battle.Enemies).Select(u=>u.Hp).ToArray();int clashes=field.ClashesPlayed;
            BeginCombat();if(!preparing||field.FormationEditing)throw new Exception("QA formação/início liberados durante entrada");
            await ToSignal(GetTree().CreateTimer(.96),SceneTreeTimer.SignalName.Timeout);await Capture("-clash");
            await ToSignal(GetTree().CreateTimer(1.7),SceneTreeTimer.SignalName.Timeout);await Capture("-formation");
            if(field.EntranceActive||!preparing||!field.FormationEditing||field.ClashesPlayed!=clashes+1||!hp.SequenceEqual(battle.Allies.Concat(battle.Enemies).Select(u=>u.Hp)))throw new Exception("QA entrada, som ou dano");
            foreach(var ally in battle.Allies)if(field.CellFoot(true,ally.Column,ally.Layer).Y<field.Size.Y*.42f)throw new Exception("QA combatente fora do chão");
            BeginCombat();if(preparing||field.FormationEditing||field.EntranceActive)throw new Exception("QA início repetiu entrada");
            ChooseSkillTarget(game.Catalog.Ability("rush"));await Capture("-skills");
            if(!field.GetGlobalRect().Encloses(skillActions.GetGlobalRect()))throw new Exception("QA ações cortadas");
            var passive=skillBar.GetChildren().OfType<SkillIconButton>().Single(b=>b.Passive);passive.EmitSignal(BaseButton.SignalName.Pressed);if(!skillDescription.Text.Contains("PASSIVA"))throw new Exception("QA passiva");
            ShowCharacterCards();await Capture("-hero");
            GD.Print("QA_V24_HOME_CAROUSEL_RAIZEN_SETTINGS_TRAINING_LOCK_MAP_GROUND_CLASH_AUDIO_FORMATION_SKILL_PANEL_OK");GetTree().Quit();
        }catch(Exception e){GD.PrintErr(e);GetTree().Quit(1);}
    }
}
