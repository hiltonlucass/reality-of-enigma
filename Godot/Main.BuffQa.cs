using Godot;
using Vaelorn;
using System;
using System.Linq;

public partial class Main
{
    private async System.Threading.Tasks.Task CaptureBuffQa(string file)
    {
        auto=false;training=null;mode="demo";
        var chef=game.Catalog.Hero("savor");
        var savor=new Unit(chef with {Stats=chef.Stats with {Speed=200}},20);
        var friend=new Unit(game.Catalog.Hero("aelia"),20,false,1,0);
        battle=new Battle(game.Catalog,new[]{savor,friend},new[]{new Unit(game.Catalog.Hero("varkhan"),20,true)});
        field.Bind(battle);var hp=battle.Allies.Concat(battle.Enemies).ToDictionary(u=>u,u=>u.Hp);
        if(!battle.TryAct("first_fish",null,out var error))throw new Exception(error);
        field.Animate(hp);Refresh();
        if(friend.BuffSpeed!=.1||battle.LastImpacts.Count!=0)throw new Exception("QA buff: bônus/dano incorreto");
        if(!Battlefield.UsesCookingAtlas(savor,true,true,10,"buff")||Battlefield.UsesCookingAtlas(savor,false,true,10,"buff")||Battlefield.UsesCookingAtlas(savor,true,true,10,"hit")||Battlefield.UsesCookingAtlas(savor,true,false,10,"buff")||Battlefield.UsesCookingAtlas(savor,true,true,.1f,"buff"))throw new Exception("QA panela fora da conjuração");
        await ToSignal(GetTree().CreateTimer(.75),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-buff.png");
        await ToSignal(GetTree().CreateTimer(1),SceneTreeTimer.SignalName.Timeout);
        await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-idle.png");
        Start("cast");await ToSignal(RenderingServer.Singleton,RenderingServer.SignalName.FramePostDraw);SaveQaImage(file+"-cast.png");
        GD.Print("QA_COOKING_ONLY_DURING_BUFF_OK CAST_PREVIEW_OK");
    }
}
