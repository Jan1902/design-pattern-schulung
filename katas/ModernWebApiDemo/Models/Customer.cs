namespace ModernWebApiDemo.Models;

public enum CustomerSegment
{
    Standard,
    Bulk,        // Optiker-Großhändler
    Premium,     // VIP-Kunden mit Sonderkonditionen
}

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public CustomerSegment Segment { get; set; }
}
