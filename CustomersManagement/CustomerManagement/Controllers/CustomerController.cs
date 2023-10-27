using System.Collections;
using System.Net.Mime;
using AutoMapper;
using CusomerManagement.DTOs;
using CusomerManagement.Mappers;
using CusomerManagement.Models;
using CusomerManagement.Services;
using CusomerManagement.Validators;
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
    private readonly ICustomerRequestValidator customerRequestValidator;
    private readonly IMapper mapper;

    public CustomerManagementController(ILogger<CustomerManagementController> logger,
        ICustomerService customerService,
        ICustomerRequestValidator customerRequestValidator,
        IMapper mapper)
    {
        this.logger = logger;
        this.customerService = customerService;
        this.customerRequestValidator = customerRequestValidator;
        this.mapper = mapper;
    }

    [HttpGet]
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
        if(!customerRequestValidator.doesAddressExist(customerRequest))
        {
            return BadRequest("A customer must have at least one address");
        }

        Customer customer = mapper.Map<Customer>(customerRequest);
        Customer dbCustomer = customerService.create(customer);

        CustomerResponseDTO customerResponse = mapper.Map<CustomerResponseDTO>(customer);

        return CreatedAtAction(nameof(GetById), new { id = customerResponse.Id }, customerResponse);
    }

    [HttpPatch("{customerId}")]
    public ActionResult<CustomerResponseDTO> Patch(int customerId,
        [FromBody] JsonPatchDocument<Customer> patch)
    {
        if (patch != null)
        {
            Customer customer = this.customerService.getById(customerId);

            patch.ApplyTo(customer, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.customerService.update(customer);


            CustomerResponseDTO customerResponse = mapper.Map<CustomerResponseDTO>(customer);

            return Ok(customerResponse);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{customerId}")]
    public ActionResult<CustomerResponseDTO> JsonPatchWithModelState(int customerId,
        [FromBody] JsonPatchDocument<Customer> patch)
    {
        if (patch != null)
        {
            Customer customer = this.customerService.getById(customerId);

            patch.ApplyTo(customer, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.customerService.update(customer);


            CustomerResponseDTO customerResponse = mapper.Map<CustomerResponseDTO>(customer);

            return Ok(customerResponse);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpDelete("{customerId}")]
    public ActionResult Delete(int customerId)
    {
        customerService.delete(customerId);
        return Ok();
    }
}
