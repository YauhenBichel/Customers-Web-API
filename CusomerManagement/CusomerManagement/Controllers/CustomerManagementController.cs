using System.Collections;
using System.Net.Mime;
using AutoMapper;
using CusomerManagement.DTOs;
using CusomerManagement.Mappers;
using CusomerManagement.Models;
using CusomerManagement.Services;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<CustomerResponseDTO>> GetAll(bool activeOnly)
    {
        IEnumerable<Customer> customers = customerService.getAll(activeOnly);

        IEnumerable<CustomerResponseDTO> customerResponses =
            customers.Select(customer => mapper.Map<CustomerResponseDTO>(customer));

        return Ok(customerResponses);
    }

    [HttpGet("{id}")]
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
    public ActionResult<CustomerResponseDTO> Create(CustomerRequestDTO customerRequest)
    {
        Customer customer = mapper.Map<Customer>(customerRequest);
        Customer dbCustomer = customerService.create(customer);

        CustomerResponseDTO customerResponse = mapper.Map<CustomerResponseDTO>(customer);

        return CreatedAtAction(nameof(GetById), new { id = customerResponse.Id }, customerResponse);
    }

    [HttpPatch("{id}")]
    public ActionResult<CustomerResponseDTO> JsonPatchWithModelState([FromBody] JsonPatchDocument<Customer> patchDoc, int id)
    {
        if (patchDoc != null)
        {
            Customer customer = this.customerService.getById(id);

            patchDoc.ApplyTo(customer);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomerResponseDTO customerResponse = mapper.Map<CustomerResponseDTO>(customer);

            return Ok(customerResponse);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        customerService.delete(id);
        return Ok();
    }
}
