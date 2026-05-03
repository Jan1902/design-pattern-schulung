using Microsoft.AspNetCore.Mvc;
using ModernWebApiDemo.Services.Customers;

namespace ModernWebApiDemo.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var customer = await _customerService.GetCustomerAsync(id);
        return customer is null ? NotFound() : Ok(customer);
    }
}