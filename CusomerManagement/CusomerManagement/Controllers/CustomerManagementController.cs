using System.Collections;
using CusomerManagement.Models;
using CusomerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CusomerManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerManagementController : ControllerBase
{
    private readonly ILogger<CustomerManagementController> logger;
    private readonly ICustomerService customerService;

    public CustomerManagementController(ILogger<CustomerManagementController> logger, ICustomerService customerService)
    {
        this.logger = logger;
        this.customerService = customerService;
    }

    [HttpGet(Name = "GetAllCustomers")]
    public IEnumerable<Customer> Get()
    {
        return new List<Customer>();
    }

    //[HttpPost]
    //public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    //{
        
    //}
}

