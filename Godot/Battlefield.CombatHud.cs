using Godot;
using Vaelorn;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class Battlefield
{
    private readonly Dictionary<Unit,(int Freeze,int Stun,int Ice)> visualState=new(),previousState=new();
    private readonly Dictionary<Unit,double> stateAt=new();
    private void ResetVisualStates(){visualState.Clear();previousState.Clear();stateAt.Clear();if(Battle!=null)foreach(var u in Battle.AlliedTargets.Concat(Battle.EnemyTargets))visualState[u]=(u.Freeze,u.Stun,u.Ice);}
    private void DelayVisualStates(){
        foreach(var u in Battle!.Allies.Concat(Battle.Enemies)){
            previousState[u]=visualState.GetValueOrDefault(u,(u.Freeze,u.Stun,u.Ice));
            visualState[u]=(u.Freeze,u.Stun,u.Ice);
            var hits=Battle.LastImpacts.Where(h=>h.Target==u).ToArray();
            stateAt[u]=hits.Length>0?clock+hits.Max(h=>ImpactDelay(h)):clock;
        }
    }
    private (int Freeze,int Stun,int Ice) ShownState(Unit u)=>clock<stateAt.GetValueOrDefault(u)?previousState[u]:(u.Freeze,u.Stun,u.Ice);
    public bool VisualFrozen(Unit unit)=>ShownFreeze(unit)>0;
    private int ShownFreeze(Unit u)=>ShownState(u).Freeze;
    private int ShownStun(Unit u)=>ShownState(u).Stun;
    private int ShownIce(Unit u)=>ShownState(u).Ice;
    private void DrawTurnRail(){
        if(Battle==null||FormationEditing||EntranceActive)return;
        var queue=(IsAnimating&&actor!=null?new[]{actor}.Concat(Battle.TurnPreview):Battle.TurnPreview).Distinct().Take(8).ToArray();
        DrawRect(new Rect2(5,51,66,Math.Min(8,queue.Length)*56+27),new Color(.025f,.04f,.07f,.82f));
        Text("TURNOS",new Vector2(10,68),gold,11);
        for(int i=0;i<queue.Length;i++){
            var u=queue[i];var at=new Vector2(15,78+i*56);
            var color=Battle.Allies.Contains(u.Origin??u)?blue:new Color("ed8d87");
            DrawCircle(at+new Vector2(22,21),24,new Color(color,i==0?.95f:.5f));
            if(Portrait(u,out var texture,out var crop))DrawTextureRectRegion(texture,new Rect2(at,new Vector2(44,42)),crop);
            Text((i+1).ToString(),at+new Vector2(-7,12),Colors.White,12);
            DrawRect(new Rect2(at+new Vector2(0,45),new Vector2(44,3)),new Color("182331"));
            DrawRect(new Rect2(at+new Vector2(0,45),new Vector2(44*(float)(DisplayHp(u)/u.MaxHp),3)),color);
        }
    }
}
