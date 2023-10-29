using System.Collections;
using System.Net.Mime;
using AutoMapper;
using CustomerManagement.DTOs;
using CustomerManagement.Mappers;
using CustomerManagement.Models;
using CustomerManagement.Services;
using CustomerManagement.Validators;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers;

[ApiController]
[Route("api/customer")]
[Produces(MediaTypeNames.Application.Json)]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> logger;
    private readonly ICustomerService customerService;
    private readonly IAddressRequestValidator addressRequestValidator;
    private readonly IMapper mapper;

    public CustomerController(ILogger<CustomerController> logger,
        ICustomerService customerService,
        IAddressRequestValidator addressRequestValidator,
        IMapper mapper)
    {
        this.logger = logger;
        this.customerService = customerService;
        this.addressRequestValidator = addressRequestValidator;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CustomerResponseDTO>> GetAll(bool activeOnly)
    {
        IEnumerable<Customer> customers = customerService.GetAll(activeOnly);

        IEnumerable<CustomerResponseDTO> customerResponses =
            customers.Select(customer => mapper.Map<CustomerResponseDTO>(customer));

        return Ok(customerResponses);
    }

    [HttpGet("{id}")]
    public ActionResult<CustomerResponseDTO> GetById(int id)
    {
        Customer dbCustomer = customerService.GetById(id);
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
        if (!addressRequestValidator.DoesOnlyOneMainAddressExist(customerRequest.Addresses))
        {
            return BadRequest("A customer must have at least one address and only one main address");
        }
        if (addressRequestValidator.DoesDuplicatesExist(customerRequest.Addresses))
        {
            return BadRequest("A customer has duplicated addresses");
        }

        Customer customer = mapper.Map<Customer>(customerRequest);
        Customer dbCustomer = customerService.Create(customer);

        CustomerResponseDTO customerResponse = mapper.Map<CustomerResponseDTO>(customer);

        return CreatedAtAction(nameof(GetById), new { id = customerResponse.Id }, customerResponse);
    }

    [HttpPatch("{customerId}")]
    public ActionResult<CustomerResponseDTO> Patch(int customerId,
        [FromBody] JsonPatchDocument<Customer> patch)
    {
        if (patch != null)
        {
            Customer customer = this.customerService.GetById(customerId);

            patch.ApplyTo(customer, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.customerService.Update(customer);


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
        customerService.Delete(customerId);
        return Ok();
    }
}
