using Godot;
using System.Text.Json;
using System.Collections.Generic;

public record JourneyRegion(int Number,string Name,string Summary,string Ending,string Art);
public record HeroStory(string Title,string Affiliation,string History);
public static class JourneyData
{
    public static readonly string[] Revealed={"kael","savor","aelia","brakk","lyra","varkas","sevrin"};
    public static JourneyRegion[] Regions=>regions??=JsonSerializer.Deserialize<JourneyRegion[]>(Godot.FileAccess.GetFileAsString("res://Data/regions.json"))!;
    public static Dictionary<string,HeroStory> Stories=>stories??=JsonSerializer.Deserialize<Dictionary<string,HeroStory>>(Godot.FileAccess.GetFileAsString("res://Data/hero-stories.json"))!;
    private static JourneyRegion[]? regions;
    private static Dictionary<string,HeroStory>? stories;
    public static int UnlockedRegion(int completed)=>System.Math.Clamp(completed/10,0,6);
}
