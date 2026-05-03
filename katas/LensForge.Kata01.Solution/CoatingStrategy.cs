using LensForge.Shared;

namespace LensForge.Kata01.Solution;

internal interface ICoatingStrategy
{
    string Name { get; }
    CoatingResult Apply(Lens lens, int intensity);
}

internal class AntiReflexCoating : ICoatingStrategy
{
    public string Name => "AR";

    public CoatingResult Apply(Lens lens, int intensity)
    {
        if (intensity < 30)
            return new CoatingResult(lens, Name, false, "Intensität zu niedrig");

        Vis.Step("Coating", "Trage Anti-Reflex-Schicht auf");
        Thread.Sleep(400);
        Vis.Step("Coating", "Härte UV-aktiv aus");
        Thread.Sleep(200);
        return new CoatingResult(lens, Name, true, null);
    }
}

// HardeningCoating, UvFilterCoating, BlueLightPremiumCoating, MirrorCoating
// jeweils analog

internal class CoatingStation
{
    private readonly Dictionary<string, ICoatingStrategy> _strategies;

    public CoatingStation(IEnumerable<ICoatingStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(s => s.Name.ToLower());
    }

    public CoatingResult ApplyCoating(Lens lens, string type, int intensity)
    {
        Vis.Step("Coating", $"Verarbeite Linse {lens.Id} ({type})");

        if (!_strategies.TryGetValue(type, out var strategy))
            throw new NotSupportedException($"Coating '{type}' unbekannt");

        return strategy.Apply(lens, intensity);
    }
}