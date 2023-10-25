using System;
using CusomerManagement.Models;
using System.ComponentModel.DataAnnotations;
using CusomerManagement.Validators;

namespace CusomerManagement.DTOs
{
	public class CustomerRequestDTO : CustomerDTO
    {
        [Required]
        public List<AddressRequestDTO> Addresses { get; set; }
    }
}
