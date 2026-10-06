using Godot;

public partial class Main
{
    private void ApplyVisualTheme()
    {
        var theme=new Theme();theme.DefaultFontSize=15;theme.DefaultFont=EnigmaStyle.Font;
        StyleBoxFlat Panel(string fill,string border)=>new(){BgColor=new Color(fill),BorderColor=new Color(border),BorderWidthBottom=1,BorderWidthTop=1,BorderWidthLeft=1,BorderWidthRight=1,CornerRadiusTopLeft=6,CornerRadiusTopRight=6,CornerRadiusBottomLeft=6,CornerRadiusBottomRight=6,ContentMarginLeft=18,ContentMarginRight=18,ContentMarginTop=11,ContentMarginBottom=11};
        theme.SetStylebox("normal","Button",Panel("172632","52606a"));
        theme.SetStylebox("hover","Button",Panel("294451","d8b474"));
        theme.SetStylebox("pressed","Button",Panel("42606a","f2d79d"));
        theme.SetStylebox("disabled","Button",Panel("151d27","303b46"));
        theme.SetColor("font_color","Button",new Color("eee1c8"));
        theme.SetColor("font_disabled_color","Button",new Color("778693"));
        theme.SetColor("font_color","Label",new Color("d6dce0"));
        theme.SetConstant("separation","VBoxContainer",10);
        theme.SetConstant("h_separation","HFlowContainer",8);
        Theme=theme;
    }
}
