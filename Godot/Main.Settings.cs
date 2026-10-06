using Godot;
public partial class Main
{
    public static bool ReducedMotion{get;private set;}
    private float masterVolume=.70f;
    private void LoadPreferences(){
        if(IsQa)return;
        var config=new ConfigFile();config.Load("user://preferences.cfg");
        masterVolume=(float)config.GetValue("audio","volume",.70f);ReducedMotion=(bool)config.GetValue("video","reduced_motion",false);
        AudioServer.SetBusVolumeDb(0,Mathf.LinearToDb(Mathf.Max(.001f,masterVolume)));
        AudioServer.SetBusMute(0,masterVolume<=0);
        if((bool)config.GetValue("video","fullscreen",false))DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
    }
    private void SavePreferences(){
        if(IsQa)return;var config=new ConfigFile();config.SetValue("audio","volume",masterVolume);config.SetValue("video","reduced_motion",ReducedMotion);config.SetValue("video","fullscreen",DisplayServer.WindowGetMode()==DisplayServer.WindowMode.Fullscreen);config.Save("user://preferences.cfg");
    }
    private void ShowSettings(){
        var root=NewMenuRoot();var shade=new ColorRect{Color=new Color("090f1c")};root.AddChild(shade);Place(shade,0,0,1,1);
        var panel=new EnigmaPanel();root.AddChild(panel);Place(panel,.22f,.20f,.78f,.80f);
        var box=new VBoxContainer();box.AddThemeConstantOverride("separation",24);panel.AddChild(box);
        box.AddChild(MenuLabel("Configurações",32));box.AddChild(MenuLabel("Volume dos efeitos",18));
        var volume=new HSlider{MinValue=0,MaxValue=100,Step=1,Value=masterVolume*100,CustomMinimumSize=new Vector2(0,40)};box.AddChild(volume);
        volume.ValueChanged+=value=>{masterVolume=(float)value/100;AudioServer.SetBusVolumeDb(0,Mathf.LinearToDb(Mathf.Max(.001f,masterVolume)));AudioServer.SetBusMute(0,masterVolume<=0);SavePreferences();};
        var fullscreen=new CheckButton{Text="Tela cheia",ButtonPressed=DisplayServer.WindowGetMode()==DisplayServer.WindowMode.Fullscreen};box.AddChild(fullscreen);fullscreen.Toggled+=on=>{DisplayServer.WindowSetMode(on?DisplayServer.WindowMode.Fullscreen:DisplayServer.WindowMode.Windowed);SavePreferences();};
        var motion=new CheckButton{Text="Reduzir movimento do menu",ButtonPressed=ReducedMotion};box.AddChild(motion);motion.Toggled+=on=>{ReducedMotion=on;SavePreferences();};
        Button(box,"Voltar ao início",ShowHomeMenu);
    }
}
