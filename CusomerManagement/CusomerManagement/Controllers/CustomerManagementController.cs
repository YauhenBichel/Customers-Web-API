using System.Collections;
using System.Net.Mime;
using CusomerManagement.Models;
using CusomerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CusomerManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Customer>> GetAll(bool activeOnly)
    {
        IEnumerable<Customer> customers = customerService.getAll(activeOnly);

        return Ok(customers);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<Customer> GetById(int id)
    {
        Customer dbCustomer = customerService.getById(id);
        if(dbCustomer == null)
        {
            return NotFound();
        }

        return Ok(dbCustomer);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Customer> Create(Customer customer)
    {
        Customer dbCustomer = customerService.create(customer);

        return CreatedAtAction(nameof(GetById), new { id = dbCustomer.Id }, customer);
    }
}

