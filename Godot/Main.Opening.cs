using Godot;

public partial class Main
{
    private void ShowOpening(bool enterCampaign)
    {
        auto=false;CloseMenu();
        var scene=new OpeningScene{ZIndex=50};AddChild(scene);scene.SetAnchorsAndOffsetsPreset(LayoutPreset.FullRect);
        scene.Leave=ShowHomeMenu;
        scene.Finished=()=>{
            if(enterCampaign){game.Save.OpeningSeen=true;game.Save.ForestEncounterSeen=true;Persist();Start("campaign");}
            else Start("story");
        };
    }
}
