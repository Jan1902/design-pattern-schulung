using LensForge.Shared;

namespace LensForge.Kata04.Solution;

public class PackagingFactory
{
    public IPackaging CreateFor(CustomerType customerType) => customerType switch
    {
        CustomerType.EndCustomer => new PappkartonPackaging(),
        CustomerType.OpticianWholesale => new HolzkistePackaging(),
        CustomerType.Laboratory => new SterilboxPackaging(),
        CustomerType.ExpressSecure => new ExpressSecureBox(),
        CustomerType.WholesaleExport => new ReinforcedExportCrate(),
        _ => throw new NotSupportedException($"Kein Packaging für {customerType}")
    };
}