using Godot;
using System;
using System.Linq;
using Vaelorn;

public partial class Main
{
    private async System.Threading.Tasks.Task CaptureOpeningQa(string file)
    {
        bool before=game.Save.OpeningSeen;
        ShowOpening(false);
        var opening=GetChildren().OfType<OpeningScene>().Single();
        for(int i=0;i<8;i++){
            opening.SetShot(i);
            await ToSignal(GetTree().CreateTimer(.8),SceneTreeTimer.SignalName.Timeout);
            await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);
            SaveQaImage(file+$"-opening-{i}.png");
        }
        if(before!=game.Save.OpeningSeen)throw new Exception("QA replay alterou progresso");
        opening.QueueFree();
        // New flags must survive persistence while missing properties remain compatible with old saves.
        var json=System.Text.Json.JsonSerializer.Serialize(game.Save);
        var copy=System.Text.Json.JsonSerializer.Deserialize<SaveData>(json)!;
        if(copy.OpeningSeen!=before)throw new Exception("QA flag do prólogo");
        GD.Print("QA_OPENING_8_SHOTS_REPLAY_PROGRESS_OK");
    }
}
