using System;
using AutoMapper;
using CustomerManagement.DTOs;
using CustomerManagement.Models;

namespace CustomerManagement.Mappers
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