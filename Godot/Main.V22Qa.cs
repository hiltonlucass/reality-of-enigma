using Godot;
using Vaelorn;
using System;
using System.Linq;
using System.Text.Json;

public partial class Main
{
    private async System.Threading.Tasks.Task CaptureV22Qa(string file)
    {
        var before=JsonSerializer.Serialize(game.Save);
        foreach(var skill in game.Catalog.Skills)if(SkillIconButton.CellFor(skill.Id)<0)throw new Exception("QA ícone ausente");
        if(game.Catalog.Skills.Select(s=>SkillIconButton.CellFor(s.Id)).Distinct().Count()!=game.Catalog.Skills.Length)throw new Exception("QA ícones repetidos");
        var frames=JsonDocument.Parse(Godot.FileAccess.GetFileAsString("res://Data/animations.json"));
        foreach(var id in new[]{"kael","savor","brakk","lyra","aelia","raizen"})if(frames.RootElement.GetProperty(id+"_action").GetProperty("Frames").GetArrayLength()!=8)throw new Exception("QA quadros de ação");
        Start("story");
        if(!field.ForestEnvironment||!battle!.Allies.Select(u=>u.Id).SequenceEqual(new[]{"kael","savor","aelia","brakk","raizen"}))throw new Exception("QA primeiro encontro narrativo");
        preparing=true;field.FormationEditing=true;Refresh();
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-forest-formation.png");
        field.FormationEditing=false;field.BeginEntrance();Refresh();
        if(!field.EntranceActive)throw new Exception("QA entrada ausente");
        await ToSignal(GetTree().CreateTimer(.45),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-entrance.png");
        await ToSignal(GetTree().CreateTimer(2.2),SceneTreeTimer.SignalName.Timeout);
        if(field.EntranceActive)throw new Exception("QA entrada não terminou");
        BeginCombat();
        var passive=skillBar.GetChildren().OfType<SkillIconButton>().Single(b=>b.Passive);
        var actor=battle.NextActor;
        passive.EmitSignal(BaseButton.SignalName.Pressed);
        if(!skillDescription.Text.Contains("PASSIVA")||battle.NextActor!=actor||battle.LastActor!=null)throw new Exception("QA consulta de passiva executou ação");
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-passive.png");
        ChooseSkillTarget(game.Catalog.Ability("rush"));
        if(pendingSkill!="rush"||battle.LastActor!=null||skillBar.GetChildren().OfType<SkillIconButton>().Count()!=3)throw new Exception("QA roda desapareceu ao selecionar");
        await ToSignal(GetTree(),SceneTree.SignalName.ProcessFrame);
        var wheel=skillBar.GetGlobalRect();var arena=field.GetGlobalRect();
        if(Math.Abs(wheel.GetCenter().X-arena.GetCenter().X)>2||wheel.End.Y>arena.End.Y||wheel.Position.Y<arena.Position.Y+arena.Size.Y*.5)throw new Exception("QA roda fora do centro inferior");
        foreach(var icon in skillBar.GetChildren().OfType<SkillIconButton>())if(!arena.Encloses(icon.GetGlobalRect()))throw new Exception("QA ícone cortado");
        if(!arena.Encloses(skillActions.GetGlobalRect()))throw new Exception("QA confirmação fora da arena: "+skillActions.GetGlobalRect()+" / "+arena);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-wheel.png");
        if(before!=JsonSerializer.Serialize(game.Save))throw new Exception("QA replay alterou save");
        // Resolve a real preview fight through the ordinary reward path; preview must grant nothing.
        for(int n=0;n<400&&!battle.Finished;n++)Step();
        await ToSignal(GetTree().CreateTimer(2),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-ending.png");
        if(before!=JsonSerializer.Serialize(game.Save)||!battle.Finished)throw new Exception("QA fim do replay/progresso");
        GD.Print("QA_V22_UNIQUE_ICONS_48_FRAMES_FOREST_PARTY_CENTER_WHEEL_PASSIVE_PREVIEW_END_OK");
    }
}
