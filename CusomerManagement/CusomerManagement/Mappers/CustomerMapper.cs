using System;
using AutoMapper;
using CusomerManagement.DTOs;
using CusomerManagement.Models;

namespace CusomerManagement.Mappers
{
	public class CustomerMapper : Profile
	{
		public CustomerMapper()
		{
			CreateMap<Customer, CustomerResponseDTO>();
			CreateMap<CustomerRequestDTO, Customer>();
		}
	}
}