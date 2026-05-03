namespace LensForge.Shared;

public record Lens(string Id, LensType Type, int DiameterMm);
public enum LensType { Standard, HighIndex, Photochromic }
public record CoatingResult(Lens Lens, string CoatingApplied, bool Success, string? ErrorMessage);