using Godot;
using Vaelorn;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class Battlefield
{
    public bool ContinuousAuto {get;set;}
    public bool PlaybackPaused {get;set;}
    public int PlaybackSpeed {get;set;}=1;
    private readonly Dictionary<Unit,(Vector2 From,double At)> returns=new();
    private double releaseAt=-10;
    public bool ReadyForNextAction=>!EntranceActive&&!ExitActive&&clock>=releaseAt;
    private bool Returning(Unit u)=>returns.TryGetValue(u,out var r)&&clock-r.At<.52&&u.Alive&&ShownFreeze(u)==0&&ShownStun(u)==0;
    public void ReleaseAction()
    {
        if(!ContinuousAuto||Battle==null)return;
        foreach(var u in Battle.AlliedTargets.Concat(Battle.EnemyTargets).Where(IsMelee))
        {
            var at=GroundPosition(u);
            returns[u]=(at,clock);
        }
    }
    private void SetReleaseTime()
    {
        // Never advance the rules before the last displayed impact/status transition.
        var last=Battle!.LastImpacts.Select(ImpactDelay).DefaultIfEmpty(HitMoment).Max();
        releaseAt=clock+Math.Max(1.08,last+.18);
        if(Battle.LastSkill?.Id=="gale_fangs")releaseAt=clock+EffectDuration;
        if(actor!=null)returns.Remove(actor);
    }
}
