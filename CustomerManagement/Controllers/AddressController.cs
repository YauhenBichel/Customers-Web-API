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
[Route("api/Customer/{customerId}/Address")]
[Produces(MediaTypeNames.Application.Json)]
public class AddressController : ControllerBase
{
    private readonly ILogger<AddressController> logger;
    private readonly IMapper mapper;
    private readonly IAddressService addressService;

    public AddressController(ILogger<AddressController> logger,
        IMapper mapper,
        IAddressService addressService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.addressService = addressService;
    }

    public ActionResult<List<AddressResponseDTO>> GetAllByCustomerId(int customerId)
    {
        IEnumerable<Address> addresses = addressService.GetAllByCustomerId(customerId);
        if (addresses == null)
        {
            return NotFound();
        }

        List<AddressResponseDTO> addressResponseDTOs =
            addresses.Select(address => mapper.Map<AddressResponseDTO>(address))
            .ToList();

        return Ok(addressResponseDTOs);
    }

    [HttpGet("{addressId}")]
    public ActionResult<AddressResponseDTO> GetById(int customerId, int addressId)
    {
        Address dbAddress = addressService.GetById(customerId, addressId);
        if (dbAddress == null)
        {
            return NotFound();
        }

        AddressResponseDTO addressResponse = mapper.Map<AddressResponseDTO>(dbAddress);

        return Ok(addressResponse);
    }
}
