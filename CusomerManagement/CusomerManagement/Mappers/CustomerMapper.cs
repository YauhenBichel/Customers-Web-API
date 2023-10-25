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
			CreateMap<Customer, CustomerResponseDTO>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));

            CreateMap<CustomerRequestDTO, Customer>()
				.ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));
        }
	}
}