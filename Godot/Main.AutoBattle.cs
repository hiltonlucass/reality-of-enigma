using Godot;
using Vaelorn;
using System;
using System.Linq;

public partial class Main
{
    private bool demoLaunch;
    private Button playbackPace=null!;
    private void TogglePlayback()
    {
        if(battle==null||preparing||battle.Finished)return;
        auto=!auto;field.PlaybackPaused=!auto;Refresh();
    }
    private void RefreshAutoSkills()
    {
        if(battle==null)return;
        playbackPace.Text=field.PlaybackSpeed+"×";
        skillDescription.GetParent().GetParent().GetNode<Control>("ActivePortrait").Visible=!preparing;
        if(preparing&&field.EntranceActive){skillDescription.Text="";return;}
        if(preparing)
        {
            var selected=field.Selected;
            if(selected==null||!battle.Allies.Contains(selected))selected=battle.Allies[0];
            skillDescription.Text=$"{selected.Definition.Name} • prioridade automática\nArraste os aliados para ajustar a formação.\nOrdem aliada: "+string.Join(" → ",battle.TurnPreview.Where(battle.Allies.Contains).Take(5).Select(u=>u.Definition.Name));
            var profile=new OptionButton();
            string[] ids={"balanced","aggressive","defensive","support","control"};
            string[] names={"Equilibrado","Agressivo","Defensivo","Suporte","Controle"};
            foreach(var name in names)profile.AddItem(name);
            profile.Selected=Math.Max(0,Array.IndexOf(ids,battle.Behaviors.GetValueOrDefault(selected,game.Catalog.AutoBattle.Characters.GetValueOrDefault(selected.Id,"balanced"))));
            var unit=selected;profile.ItemSelected+=index=>battle.Behaviors[unit]=ids[(int)index];skillActions.AddChild(profile);
            Button(skillActions,"Iniciar combate automático",BeginCombat);return;
        }
        field.SetTargetIntent(battle.LastSkill);
        if(battle.Finished&&mode=="flow"){
            skillDescription.Text=(battle.Won?"Vitória":"Derrota")+" • demonstração 5×5\nSem recompensas ou alterações no seu save.";
            Button(skillActions,"Nova formação",()=>Start("flow"));Button(skillActions,"Voltar ao início",ShowHomeMenu);return;
        }
        skillDescription.Text=battle.Finished?(battle.Won?"Vitória":"Derrota"):
            field.PlaybackPaused?"Combate pausado":battle.LastSkill==null?"":$"{battle.LastActor?.Definition.Name} • {battle.LastSkill.Name}";
    }
    private async void CaptureAutoQa()
    {
        try
        {
            var args=OS.GetCmdlineUserArgs();string file=args[Array.IndexOf(args,"--qa-auto")+1];
            Start("flow");preparing=true;field.FormationEditing=true;Refresh();
            await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);
            await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-formation.png");
            field.PlaybackSpeed=3;BeginCombat();int frames=0;
            while(!battle!.Finished&&frames++<18000)
            {
                await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);
                if(frames==160||frames==300){await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-action-"+frames+".png");}
            }
            if(!battle.Finished||battle.Allies.Count!=5||battle.Enemies.Count!=5)throw new Exception("Auto 5x5 did not finish");
            await ToSignal(GetTree().CreateTimer(2),SceneTreeTimer.SignalName.Timeout);
            await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-result.png");
            GD.Print("QA_AUTO_5V5_COMPLETED round="+battle.Round);GetTree().Quit();
        }catch(Exception e){GD.PrintErr(e);GetTree().Quit(1);}
    }
}
