namespace ModernWebApiDemo.Models;

public enum LensType
{
    Standard,
    HighIndex,
    Photochromic,
}

public class Lens
{
    public Guid Id { get; set; }
    public LensType Type { get; set; }
    public int DiameterMm { get; set; }
    public decimal BasePrice { get; set; }
}