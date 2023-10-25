using System;
using AutoMapper;
using CusomerManagement.DTOs;
using CusomerManagement.Models;

namespace CusomerManagement.Mappers
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