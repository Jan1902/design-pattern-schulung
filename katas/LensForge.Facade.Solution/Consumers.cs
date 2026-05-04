using LensForge.Facade;
using LensForge.Shared;

namespace LensForge.Facade.Solution;

public class CustomerOrderController(LensProductionFacade production)
{
    private readonly LensProductionFacade _production = production;

    public ShipmentReceipt? PlaceOrder(Lens lens, CustomerType customer)
        => _production.ProduceAndShip(lens, customer, "CustomerOrder");
}

public class BatchProductionJob(LensProductionFacade production)
{
    private readonly LensProductionFacade _production = production;

    public void RunNightlyBatch(IEnumerable<(Lens lens, CustomerType customer)> orders)
    {
        foreach (var (lens, customer) in orders)
            _production.ProduceAndShip(lens, customer, "BatchJob");
    }
}

public class SampleProductionRequest(LensProductionFacade production)
{
    private readonly LensProductionFacade _production = production;

    public ShipmentReceipt? CreateSample(Lens lens, string salesContactAddress)
        => _production.ProduceAndShip(lens, CustomerType.EndCustomer, "SalesSample");
}