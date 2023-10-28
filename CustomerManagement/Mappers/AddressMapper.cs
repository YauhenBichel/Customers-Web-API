using System;
using AutoMapper;
using CustomerManagement.DTOs;
using CustomerManagement.Models;

namespace CustomerManagement.Mappers
{
	public class AddressMapper : Profile
	{
		public AddressMapper()
		{
			CreateMap<Address, AddressResponseDTO>();
			CreateMap<AddressRequestDTO, Address>();
		}
    }
}