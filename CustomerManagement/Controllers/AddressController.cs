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
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AddressController : ControllerBase
{
    private readonly ILogger<AddressController> logger;
    private readonly IMapper mapper;

    public AddressController(ILogger<AddressController> logger,
        IMapper mapper)
    {
        this.logger = logger;
        this.mapper = mapper;
    }

    
}
