using System;
using CustomerManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.DTOs
{
	public class CustomerResponseDTO : CustomerDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public List<AddressResponseDTO> Addresses { get; set; }
    }
}

