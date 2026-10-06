using Godot;
using Vaelorn;
using System.Collections.Generic;
using System.Linq;

public partial class Battlefield
{
    private readonly List<(Rect2 Area,string Text)> buffHover=new();
    private string BuffHoverText(Vector2 at)=>buffHover.FirstOrDefault(b=>b.Area.HasPoint(at)).Text??"";
    private List<(string Icon,string Description)> ActiveBuffs(Unit u)
    {
        var buffs=new List<(string,string)>();
        if(Battle==null||!u.Alive)return buffs;
        var team=Battle.Allies.Contains(u.Origin??u)?Battle.Allies:Battle.Enemies;
        var synergy=Rules.Fighters(team,u);
        var speed=new List<string>();var damage=new List<string>();
        if(u.BuffSpeed>0)speed.Add($"Inspiração +{u.BuffSpeed:P0}");
        if(synergy.Speed>0)speed.Add($"Sinergia +{synergy.Speed:P0}");
        if(u.Gate>0)speed.Add($"Portões +{.04*u.Gate+(u.Gate==8?.30:0):P0}");
        if(speed.Count>0)buffs.Add(("speed","Velocidade\n"+string.Join("\n",speed)));
        if(u.BuffStrength>0)damage.Add($"Força +{u.BuffStrength:P0}");
        if(u.BuffEssence>0)damage.Add($"Essência +{u.BuffEssence:P0}");
        if(synergy.Damage>0)damage.Add($"Sinergia +{synergy.Damage:P0}");
        if(u.Gate>0)damage.Add($"Força dos portões +{.08*u.Gate+(u.Gate==8?.25:0):P0}");
        if(damage.Count>0)buffs.Add(("damage","Poder\n"+string.Join("\n",damage)));
        if(synergy.Reduction>0)buffs.Add(("defense",$"Proteção: reduz dano recebido em {synergy.Reduction:P0}"));
        foreach(var group in u.Statuses.Where(s=>s.Effect.DamageReduction>0||s.Effect.DefenseReduction>0||s.Effect.ControlBonus>0||s.Effect.IncomingDamage!=0).GroupBy(s=>s.Effect.Id)){
            var effect=group.First().Effect;int turns=group.Max(s=>s.RemainingTurns);
            string text=effect.DefenseReduction>0?$"Defesa -{effect.DefenseReduction:P0}":effect.DamageReduction>0?$"Dano causado -{effect.DamageReduction:P0}":effect.IncomingDamage<0?$"Dano recebido {effect.IncomingDamage:P0}":$"Dano recebido +{effect.IncomingDamage:P0}";
            buffs.Add((effect.IncomingDamage<0||effect.ControlBonus>0?"defense":"weaken",text+$" • {turns} turno(s)"));
        }
        return buffs;
    }
    public string BuffDescription(Unit unit)=>string.Join("\n",ActiveBuffs(unit).Select(b=>b.Description));

    private void DrawBuffIcons(Unit unit,Vector2 origin)
    {
        var buffs=ActiveBuffs(unit);
        for(int i=0;i<buffs.Count;i++){var at=origin+new Vector2(i*21,0);DrawBuffIcon(buffs[i].Icon,at);buffHover.Add((new Rect2(at,new Vector2(18,18)),buffs[i].Description));}
    }
    private void DrawBuffIcon(string kind,Vector2 at)
    {
        var ink=new Color("d3f3ff");var dark=new Color(.02f,.03f,.06f,.85f);DrawSetTransform(at);
        DrawPolyline(new[]{new Vector2(15,4),new Vector2(18,1),new Vector2(21,4)},new Color("83d7ff"),2,true);
        if(kind=="speed"){
            var boot=new[]{new Vector2(7,2),new Vector2(13,2),new Vector2(12,10),new Vector2(17,12),new Vector2(17,16),new Vector2(3,16),new Vector2(3,12),new Vector2(7,10)};
            DrawColoredPolygon(boot,dark);DrawPolyline(boot.Append(boot[0]).ToArray(),ink,1.6f,true);DrawLine(new Vector2(1,7),new Vector2(5,7),ink,1.4f);DrawLine(new Vector2(0,10),new Vector2(4,10),ink,1.4f);
        }else if(kind=="damage"){
            DrawRect(new Rect2(3,4,13,11),dark);DrawRect(new Rect2(3,4,13,11),ink,false,1);
            for(int i=0;i<3;i++)DrawLine(new Vector2(6+i*3,3),new Vector2(6+i*3,8),ink,1.5f,true);DrawLine(new Vector2(3,10),new Vector2(8,10),ink,2,true);DrawRect(new Rect2(6,15,8,2),ink);
        }else if(kind=="weaken"){
            var red=new Color("f0a3b9");DrawLine(new Vector2(9,2),new Vector2(9,14),red,2,true);DrawPolyline(new[]{new Vector2(4,10),new Vector2(9,16),new Vector2(14,10)},red,2,true);
        }else{
            var shield=new[]{new Vector2(9,1),new Vector2(16,4),new Vector2(14,12),new Vector2(9,17),new Vector2(4,12),new Vector2(2,4),new Vector2(9,1)};DrawColoredPolygon(shield.Take(6).ToArray(),dark);DrawPolyline(shield,ink,1.6f,true);DrawLine(new Vector2(9,4),new Vector2(9,13),ink,1,true);
        }
        DrawSetTransform(Vector2.Zero);
    }
}
