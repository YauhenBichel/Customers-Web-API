using System;
using CustomerManagement.Models;
using System.ComponentModel.DataAnnotations;
using CustomerManagement.Validators;

namespace CustomerManagement.DTOs
{
	public class CustomerRequestDTO : CustomerDTO
    {
        [Required]
        public List<AddressRequestDTO> Addresses { get; set; }
    }
}
