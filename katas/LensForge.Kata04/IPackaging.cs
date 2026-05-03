using LensForge.Shared;

namespace LensForge.Kata04;

public interface IPackaging
{
    string PackagingType { get; }
    string ShippingLabel { get; }
    void PackLens(Lens lens);
    decimal Cost { get; }
}
