using System.Text.Json;
namespace Vaelorn;

public record BehaviorProfile(string Target="front",double HealBelow=.75,string[]? Skills=null);
public record AutoBattleConfig
{
    public Dictionary<string,BehaviorProfile> Profiles {get;init;}=new()
    {
        ["balanced"]=new(),["aggressive"]=new("weakest"),
        ["support"]=new("front",.9),["defensive"]=new("front",.85),
        ["control"]=new()
    };
    public Dictionary<string,string> Characters {get;init;}=new(){["aelia"]="support",["savor"]="support",["lyra"]="control",["brakk"]="defensive"};
    public static AutoBattleConfig Load(string json)=>JsonSerializer.Deserialize<AutoBattleConfig>(json,new JsonSerializerOptions{PropertyNameCaseInsensitive=true})??new();
}
public record AutoDecision(Skill Skill,Unit Target);

// Pure rules: no wall-clock, renderer or extra random source. Stable ordering is deliberate.
public static class AutoBattleAI
{
    public static AutoDecision? Choose(Unit actor,IEnumerable<Skill> available,List<Unit> own,List<Unit> foes,AutoBattleConfig config,string? behavior=null)
    {
        string mode=behavior??config.Characters.GetValueOrDefault(actor.Id,"balanced");
        var profile=config.Profiles.GetValueOrDefault(mode,new());
        var friends=Battle.Targets(own);var enemies=Battle.Targets(foes);
        if(enemies.Count==0)return null;
        var hurt=friends.OrderBy(u=>u.Hp/u.MaxHp).ThenBy(u=>u.Layer*3+u.Column).First();
        var front=enemies.OrderBy(u=>u.Layer).ThenBy(u=>u.Column==actor.Column?0:1).ThenBy(u=>u.Column).First();
        // Ordinary attacks cannot bypass the occupied front layer to execute a backliner.
        var target=profile.Target=="weakest"?enemies.Where(u=>u.Layer==front.Layer).OrderBy(u=>u.Hp).ThenBy(u=>u.Column).First():front;
        var candidates=available.Where(s=>s.Operator!="heal"||hurt.Hp/hurt.MaxHp<profile.HealBelow)
            .Where(s=>s.Operator!="buff"||friends.Any(u=>!u.Buffs.ContainsKey(s.Id)))
            .Select(s=>(Skill:s,Score:Score(s))).OrderByDescending(x=>x.Score).ThenBy(x=>x.Skill.Id,StringComparer.Ordinal).ToArray();
        if(candidates.Length==0)return null;
        var best=candidates[0].Skill;
        return new(best,best.Operator=="heal"?hurt:best.Operator is "buff" or "split" or "break" or "eclipse_guard"?actor:target);

        double Score(Skill s)
        {
            int configured=Array.IndexOf(profile.Skills??Array.Empty<string>(),s.Id);
            if(configured>=0)return 10000-configured;
            if(s.Operator=="extreme")return 1000;
            if(s.Operator=="heal")return 900+(1-hurt.Hp/hurt.MaxHp)*100;
            if(s.Operator=="split")return 800;
            if(s.Operator=="buff")return 600;
            if(s.Operator=="break")return 500;
            if(mode=="defensive"&&s.Operator=="eclipse_guard")return 700;
            double control=mode=="control"?(s.Ice*25+s.Stun*100+s.Slow*100):0;
            return control+(s.Cooldown>0?100:0)+s.Multiplier*Math.Max(1,s.Hits);
        }
    }
}
