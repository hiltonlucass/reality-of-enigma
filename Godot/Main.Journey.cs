using Godot;
using System;

public partial class Main
{
    private VBoxContainer JourneyPanel(int regionIndex,string title,string text)
    {
        var root=NewMenuRoot();
        var background=new TextureRect{Texture=GD.Load<Texture2D>(JourneyData.Regions[regionIndex].Art),ExpandMode=TextureRect.ExpandModeEnum.IgnoreSize,StretchMode=TextureRect.StretchModeEnum.KeepAspectCovered,MouseFilter=MouseFilterEnum.Ignore};root.AddChild(background);Place(background,0,0,1,1);
        var shade=new ColorRect{Color=new Color(.025f,.035f,.065f,.77f),MouseFilter=MouseFilterEnum.Ignore};root.AddChild(shade);Place(shade,0,0,1,1);
        var content=new VBoxContainer();root.AddChild(content);Place(content,.17f,.17f,.83f,.88f);content.AddThemeConstantOverride("separation",25);
        var heading=MenuLabel(title,38);heading.AddThemeColorOverride("font_color",new Color("f2d49c"));content.AddChild(heading);
        var body=MenuLabel(text,23);body.SizeFlagsVertical=SizeFlags.ExpandFill;content.AddChild(body);
        root.Modulate=new Color(1,1,1,0);root.CreateTween().TweenProperty(root,"modulate:a",1,.45);
        return content;
    }
    private void ShowCampaignOutcome()
    {
        if(battle==null||mode!="campaign")return;
        int region=(encounterStage-1)/10;
        if(battle.Won&&encounterStage%10==0&&!encounterReplay){ShowRegionEnding(region);return;}
        auto=false;CloseMenu();var root=new Control{ZIndex=40,MouseFilter=MouseFilterEnum.Ignore};menuOverlay=root;AddChild(root);Place(root,0,0,1,1);
        if(battle.Won){
            var rewards=new PanelContainer{MouseFilter=MouseFilterEnum.Ignore};
            rewards.AddThemeStyleboxOverride("panel",new StyleBoxFlat{BgColor=new Color(.055f,.025f,.095f,.94f),BorderColor=new Color("9d8059"),BorderWidthTop=1,BorderWidthBottom=1,CornerRadiusTopLeft=18,CornerRadiusTopRight=18,CornerRadiusBottomLeft=18,CornerRadiusBottomRight=18,ContentMarginLeft=20,ContentMarginRight=20,ContentMarginTop=14,ContentMarginBottom=14});
            root.AddChild(rewards);Place(rewards,.22f,.66f,.78f,.80f);
            var rewardText=MenuLabel("RECOMPENSAS RECEBIDAS\n"+game.LastCampaignReward,19);rewardText.HorizontalAlignment=HorizontalAlignment.Center;rewards.AddChild(rewardText);
        }
        if(battle.Won&&game.CanEnterStage(encounterStage+1)){
            var next=new JourneyArrow{Name="NextStageArrow",Text="Próxima fase"};root.AddChild(next);Place(next,.85f,.48f,.98f,.68f);next.Pressed+=()=>WalkToNextStage(encounterStage+1);
        }
        if(!battle.Won){var retry=new Button{Text="Tentar novamente"};root.AddChild(retry);Place(retry,.42f,.66f,.58f,.72f);retry.Pressed+=()=>StartCampaignStage(encounterStage);}
        var back=new JourneyArrow{Back=true,Name="BackToMap",Text="Voltar"};root.AddChild(back);Place(back,.06f,.12f,.16f,.21f);back.Pressed+=()=>{campaignRegion=region;ShowCampaignMenu();};

    }
    private async void WalkToNextStage(int next){
        if(field.ExitActive)return;var departingBattle=battle;CloseMenu();auto=false;field.BeginExit();
        await ToSignal(GetTree().CreateTimer(1.85),SceneTreeTimer.SignalName.Timeout);
        if(battle==departingBattle&&menuOverlay==null)StartCampaignStage(next);
    }

    private void ShowRegionEnding(int index)
    {
        var region=JourneyData.Regions[index];
        var panel=JourneyPanel(index,index==6?"ATO I • O SOL E O ABISMO":$"CENÁRIO {index+1} CONCLUÍDO",region.Ending);
        panel.AddChild(MenuLabel("RECOMPENSAS RECEBIDAS\n"+game.LastCampaignReward,18));
        if(index<6)Button(panel,$"Revelar cenário {index+2} • {JourneyData.Regions[index+1].Name}",()=>{campaignRegion=index+1;ShowCampaignMenu();});
        else Button(panel,"Sala de Treinamento • Solarius",ShowTrainingMenu);
        Button(panel,"Voltar ao mapa",()=>{campaignRegion=index;ShowCampaignMenu();});
    }
}
