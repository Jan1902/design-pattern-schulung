using ModernWebApiDemo.Models;

namespace ModernWebApiDemo.Services.Customers;

public interface ICustomerService
{
    Task<Customer?> GetCustomerAsync(Guid customerId);
}
