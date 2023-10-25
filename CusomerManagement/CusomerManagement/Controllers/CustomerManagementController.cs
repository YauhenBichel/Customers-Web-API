using System.Collections;
using System.Net.Mime;
using AutoMapper;
using CusomerManagement.DTOs;
using CusomerManagement.Mappers;
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
    private readonly IMapper mapper;

    public CustomerManagementController(ILogger<CustomerManagementController> logger,
        ICustomerService customerService,
        IMapper mapper)
    {
        this.logger = logger;
        this.customerService = customerService;
        this.mapper = mapper;
    }

    [HttpGet(Name = "GetAllCustomers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<CustomerResponseDTO>> GetAll(bool activeOnly)
    {
        IEnumerable<Customer> customers = customerService.getAll(activeOnly);

        IEnumerable<CustomerResponseDTO> customerResponses =
            customers.Select(customer => mapper.Map<CustomerResponseDTO>(customer));

        return Ok(customerResponses);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<CustomerResponseDTO> GetById(int id)
    {
        Customer dbCustomer = customerService.getById(id);
        if(dbCustomer == null)
        {
            return NotFound();
        }

        CustomerResponseDTO customerResponse = mapper.Map<CustomerResponseDTO>(dbCustomer);

        return Ok(customerResponse);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CustomerResponseDTO> Create(CustomerRequestDTO customerRequest)
    {
        Customer customer = mapper.Map<Customer>(customerRequest);
        Customer dbCustomer = customerService.create(customer);

        CustomerResponseDTO customerResponse = mapper.Map<CustomerResponseDTO>(customer);

        return CreatedAtAction(nameof(GetById), new { id = customerResponse.Id }, customerResponse);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Delete(int customerId)
    {
        customerService.delete(customerId);
        return Ok();
    }
}
