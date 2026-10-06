using Godot;
using Vaelorn;
using System;
using System.Linq;

// Portraits reuse original character art; HP follows the visible impact timeline.
public partial class PartyHud:Control
{
    public Battlefield Field=null!;
    private Texture2D cast=null!,kael=null!;
    public override void _Ready(){CustomMinimumSize=new Vector2(0,76);cast=GD.Load<Texture2D>("res://Art/combatants-v5.png");kael=GD.Load<Texture2D>("res://Art/kael-poses-v5.png");MouseFilter=MouseFilterEnum.Stop;}
    public override void _Process(double delta)=>QueueRedraw();
    private Rect2 Card(int index)=>new(index*Size.X/5,0,Size.X/5-8,74);
    public override void _GuiInput(InputEvent e){if(e is InputEventMouseButton m&&m.Pressed&&m.ButtonIndex==MouseButton.Left&&Field.Battle!=null)for(int i=0;i<Field.Battle.Allies.Count;i++)if(Card(i).HasPoint(m.Position))Field.SelectUnit(Field.Battle.Allies[i]);}
    public override void _Draw()
    {
        if(Field.Battle==null)return;
        var font=EnigmaStyle.Font;
        for(int i=0;i<Field.Battle.Allies.Count;i++){
            Unit unit=Field.Battle.Allies[i];var r=Card(i);bool active=Field.Battle.NextActor==unit;
            var accent=new Color(active?"e8cc88":Field.Selected==unit?"7cdcf0":"405268");
            using var panel=new StyleBoxFlat{BgColor=new Color("0d1624"),BorderColor=accent,BorderWidthTop=2,BorderWidthBottom=1,BorderWidthLeft=1,BorderWidthRight=1,CornerRadiusTopLeft=16,CornerRadiusTopRight=16,CornerRadiusBottomLeft=16,CornerRadiusBottomRight=16};
            if(active||Field.Selected==unit)DrawStyleBox(panel,r);
            else DrawLine(r.Position+new Vector2(65,68),r.End-new Vector2(8,6),new Color("344254"),1,true);
            Rect2 region=unit.Id switch{"kael"=>new(170,8,220,280),"savor"=>new(185,8,180,210),"aelia"=>new(685,8,190,210),"lyra"=>new(1175,8,190,210),"brakk"=>new(175,520,220,220),"varkhan"=>new(690,520,190,220),_=>new(1160,520,190,220)};
            bool hasPortrait=unit.Id is "kael" or "savor" or "aelia" or "lyra" or "brakk" or "varkhan";
            if(Field.Portrait(unit,out var revised,out var crop))DrawTextureRectRegion(revised,new Rect2(r.Position+new Vector2(8,8),new Vector2(52,58)),crop,unit.Alive?Colors.White:new Color(.45f,.45f,.5f));
            else if(hasPortrait)DrawTextureRectRegion(unit.Id=="kael"?kael:cast,new Rect2(r.Position+new Vector2(8,8),new Vector2(52,58)),region,unit.Alive?Colors.White:new Color(.45f,.45f,.5f));
            else DrawString(font,r.Position+new Vector2(17,43),unit.Definition.Name[..1],fontSize:27,modulate:accent);
            float x=r.Position.X+65,w=r.Size.X-78;
            DrawString(font,new Vector2(x,24),unit.Definition.Name+"  Nv."+unit.Level,fontSize:15,modulate:active?accent:Colors.White);
            double hp=Field.DisplayHp(unit);
            DrawRect(new Rect2(x,34,w,5),new Color("050b13"));
            DrawRect(new Rect2(x,34,w*(float)(hp/unit.MaxHp),5),new Color("70dcb2"));
            DrawString(font,new Vector2(x,57),$"{hp:F0} / {unit.MaxHp:F0}",fontSize:12,modulate:new Color("a9becd"));
            if(active)DrawCircle(new Vector2(r.End.X-12,18),3,accent);
        }
    }
}
