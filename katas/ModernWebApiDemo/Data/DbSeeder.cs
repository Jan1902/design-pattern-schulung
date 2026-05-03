using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Data;


public static class DbSeeder
{
    public static void Seed(OrderDbContext db)
    {
        if (db.Customers.Any()) return;

        db.Customers.AddRange(
            new Customer
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Alice Müller",
                Email = "alice@example.com",
                Segment = CustomerSegment.Standard,
            },
            new Customer
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Optik Schmitz GmbH",
                Email = "bestellung@optik-schmitz.de",
                Segment = CustomerSegment.Bulk,
            },
            new Customer
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Premium Eyewear AG",
                Email = "vip@premium-eyewear.com",
                Segment = CustomerSegment.Premium,
            });

        db.Lenses.AddRange(
            new Lens
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Type = LensType.Standard,
                DiameterMm = 52,
                BasePrice = 89.00m,
            },
            new Lens
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Type = LensType.HighIndex,
                DiameterMm = 54,
                BasePrice = 159.00m,
            });

        db.SaveChanges();
    }
}
