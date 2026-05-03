using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Services.Customers;

public class CustomerService(Data.OrderDbContext db) : ICustomerService
{
    private readonly Data.OrderDbContext _db = db;

    public async Task<Customer?> GetCustomerAsync(Guid customerId)
    {
        return await _db.Customers.FindAsync(customerId);
    }
}