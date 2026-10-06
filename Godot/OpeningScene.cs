using Godot;
using System;

public partial class OpeningScene:Control
{
    public Action? Finished;
    public Action? Leave;
    private Texture2D atlas=null!,forest=null!;
    private int shot;
    private double elapsed;
    private bool automatic=true,completed;
    private Label caption=null!,title=null!;
    private AudioStreamPlayer? sceneAudio;
    private readonly string[] narration={
        "Kael havia deixado a guerra para trás. Perto da Floresta de Vaelorn, dividia seus dias entre o trabalho no campo e a família.",
        "Um clarão rompeu o horizonte. A terra tremeu. Além das árvores, uma explosão rasgava o céu.\nKael: — Aquilo veio da floresta… perto demais de casa.",
        "As ferramentas ficaram para trás. Kael vestiu a antiga roupa de combate e ajustou as lâminas.\nKael: — Preciso descobrir o que aconteceu antes que chegue até aqui.",
        "Kael deixou o campo para trás. Além das árvores, a fumaça da explosão ainda marcava o céu.",
        "O silêncio da floresta parecia errado. Kael seguiu a trilha, atento a cada ruído.\nKael: — Nenhum pássaro… o que aconteceu aqui?",
        "Uma voz interrompeu seus passos.\nSavor: — Calma. Sou Savor. Somos mercenários. Você também viu a explosão?",
        "Savor apresentou Aelia, Brakk e Raizen. Procuravam o filho do governador, desaparecido havia duas semanas.\nKael: — Conheço estas trilhas. Vou com vocês. Raizen permaneceu afastado, em silêncio.",
        "Galhos estalaram. Predadores cobertos por cristais violetas saíram da mata e bloquearam o caminho.\nSavor: — Em posição! Kael: — Primeiro passamos por eles. Depois seguimos até a explosão."
    };
    public override void _Ready(){
        ClipContents=true;MouseFilter=MouseFilterEnum.Stop;
        atlas=GD.Load<Texture2D>("res://Art/prologue-v21.png");forest=GD.Load<Texture2D>("res://Art/encounter-v22.png");
        var bottom=new PanelContainer();bottom.AddThemeStyleboxOverride("panel",new StyleBoxFlat{BgColor=new Color("0b1421"),ContentMarginLeft=28,ContentMarginRight=28,ContentMarginTop=14,ContentMarginBottom=14});AddChild(bottom);bottom.SetAnchorsAndOffsetsPreset(LayoutPreset.BottomWide);bottom.OffsetTop=-190;
        var box=new VBoxContainer();bottom.AddChild(box);
        title=new Label();title.AddThemeFontSizeOverride("font_size",24);box.AddChild(title);
        caption=new Label{AutowrapMode=TextServer.AutowrapMode.WordSmart,CustomMinimumSize=new Vector2(0,78)};caption.AddThemeFontSizeOverride("font_size",19);box.AddChild(caption);
        var buttons=new HBoxContainer();box.AddChild(buttons);
        void Button(string text,Action action){var b=new Godot.Button{Text=text};b.Pressed+=action;buttons.AddChild(b);}
        Button("Anterior",()=>SetShot(Math.Max(0,shot-1)));Button("Pausar / continuar",()=>automatic=!automatic);
        Button("Avançar",Next);Button("Pular abertura",Complete);Button("Voltar ao menu",()=>{Leave?.Invoke();QueueFree();});
        SetShot(0);
    }
    public void SetShot(int index){shot=Math.Clamp(index,0,7);elapsed=0;if(title!=null){title.Text=$"PRÓLOGO  /  {new[]{"DIAS DE PAZ","A RUPTURA","O VETERANO","RUMO À FLORESTA","A TRILHA SILENCIOSA","O ENCONTRO","OS MERCENÁRIOS","PREDADORES DA FENDA"}[shot]}";caption.Text=narration[shot];}
        sceneAudio?.Stop();
        if(shot is 1 or 7&&IsInsideTree()){
            if(sceneAudio==null){sceneAudio=new AudioStreamPlayer{VolumeDb=-15};AddChild(sceneAudio);}
            sceneAudio.Stream=GD.Load<AudioStream>(shot==1?"res://Audio/BomAtomic.mp3":"res://Audio/BeastMonster.mp3");sceneAudio.Play();
        }
        QueueRedraw();}
    private void Next(){if(shot==7)Complete();else SetShot(shot+1);}
    private void Complete(){if(completed)return;completed=true;SetProcess(false);Finished?.Invoke();QueueFree();}
    public override void _Process(double delta){elapsed+=delta;if(automatic&&elapsed>9)Next();QueueRedraw();}
    public override void _Draw(){
        if(atlas==null)return;
        var texture=shot<4?atlas:forest;int local=shot%4;var cell=texture.GetSize()/2;float t=(float)Math.Min(elapsed/9,1),inset=1+t*.035f;
        var crop=cell/inset;var start=new Vector2(local%2,local/2)*cell+(cell-crop)/2;
        DrawTextureRectRegion(texture,new Rect2(0,0,Size.X,Size.Y-140),new Rect2(start,crop));
        float fade=1-Mathf.Clamp((float)elapsed/.6f,0,1);
        DrawRect(new Rect2(Vector2.Zero,Size),new Color(0,0,0,fade));
        if(shot==1&&elapsed<1){float flash=Mathf.Sin((float)elapsed*Mathf.Pi);DrawRect(new Rect2(Vector2.Zero,Size),new Color(1,.87f,.58f,flash*.24f));}
    }
}
