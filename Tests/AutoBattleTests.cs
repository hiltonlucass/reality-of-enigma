using Vaelorn;

public static class AutoBattleTests
{
    public static void Run(Catalog catalog,Action<bool,string> check)
    {
        var config=new AutoBattleConfig();
        var aelia=new Unit(catalog.Hero("aelia"));var kael=new Unit(catalog.Hero("kael"));
        var foe=new Unit(catalog.Hero("enemy_fenda"));
        var skills=aelia.Definition.Skills.Select(catalog.Ability).ToArray();
        var heal=skills.First(s=>s.Operator=="heal");
        var full=AutoBattleAI.Choose(aelia,skills,new(){aelia,kael},new(){foe},config);
        check(full?.Skill.Operator!="heal","AI never heals full-health team");
        kael.Hp=kael.MaxHp*.2;
        var wounded=AutoBattleAI.Choose(aelia,skills,new(){aelia,kael},new(){foe},config);
        check(wounded?.Skill==heal&&wounded.Target==kael,"AI heals lowest health ratio ally");
        var rear=new Unit(catalog.Hero("enemy_fenda"),column:0,layer:2);rear.Hp=1;
        var melee=AutoBattleAI.Choose(kael,new[]{catalog.Ability(kael.Definition.Skills[0])},new(){kael},new(){rear,foe},config,"aggressive");
        check(melee?.Target==foe,"Aggressive profile respects front protection");
        var savor=new Unit(catalog.Hero("savor"));var buff=catalog.Skills.First(s=>s.Operator=="buff");
        savor.ApplyBuff(buff.Id,new(0,.2,0,10));
        check(AutoBattleAI.Choose(savor,new[]{buff},new(){savor},new(){foe},config)==null,"AI waits instead of refreshing active buff");
        var custom=config with {Profiles=new(){["ordered"]=new(Skills:new[]{kael.Definition.Skills[0]})}};
        check(AutoBattleAI.Choose(kael,kael.Definition.Skills.Select(catalog.Ability),new(){kael},new(){foe},custom,"ordered")?.Skill.Id==kael.Definition.Skills[0],"Data priority overrides default scoring");
        Battle Encounter(int seed)=>new(catalog,new[]{"kael","savor","aelia","brakk","lyra"}.Select((id,i)=>new Unit(catalog.Hero(id),20,column:i%3,layer:i/3)),Enumerable.Range(0,5).Select(i=>new Unit(catalog.Hero("enemy_fenda"),20,column:i%3,layer:i/3)),seed);
        var first=Encounter(811);var second=Encounter(811);
        first.Allies[0].Hp*=.2;second.Allies[0].Hp*=.2;
        for(int i=0;i<1500&&!first.Finished;i++)first.Advance();
        // Different presentation batch sizes must not affect game rules or RNG.
        while(!second.Finished)second.Step();
        check(first.Finished&&first.Allies.Count==5&&first.Enemies.Count==5,"5v5 completes without manual commands");
        check(first.Log.SequenceEqual(second.Log)&&first.Allies.Select(u=>u.Hp).SequenceEqual(second.Allies.Select(u=>u.Hp)),"Same seed and different playback batching give identical results");
        check(first.Log.Any(l=>l.Contains("cura")),"Automatic battle uses healing");
        var order=new Battle(catalog,new[]{new Unit(catalog.Hero("kael"),column:2),new Unit(catalog.Hero("kael"),column:0)},new[]{new Unit(catalog.Hero("enemy_fenda"))});
        check(order.TurnPreview.Where(u=>u.Id=="kael").First().Column==0,"Formation cell breaks equal-speed ties");
    }
}
