using LensForge.Coating;
using LensForge.Shared;

namespace LensForge.Kata01.Tests;

public class CoatingStationTests
{
    [Fact]
    public void AntiReflex_WithSufficientIntensity_Succeeds()
    {
        var station = new CoatingStation();
        var lens = new Lens("L-T01", LensType.Standard, 52);

        var result = station.ApplyCoating(lens, "anti-reflex", 80);

        Assert.True(result.Success);
        Assert.Equal("AR", result.CoatingApplied);
    }

    [Fact]
    public void Hardening_OnPhotochromicLens_Fails()
    {
        var station = new CoatingStation();
        var lens = new Lens("L-T02", LensType.Photochromic, 54);

        var result = station.ApplyCoating(lens, "hardening", 100);

        Assert.False(result.Success);
    }

    [Fact]
    public void UvFilter_WithLowIntensity_Fails()
    {
        var station = new CoatingStation();
        var lens = new Lens("L-T03", LensType.Standard, 50);

        var result = station.ApplyCoating(lens, "uv-filter", 30);

        Assert.False(result.Success);
    }

    // Diese Tests müssen nach dem Refactoring ergänzt werden:
    // - BlueLightPremium_WithSufficientIntensity_Succeeds
    // - Mirror_AppliesSuccessfully
}