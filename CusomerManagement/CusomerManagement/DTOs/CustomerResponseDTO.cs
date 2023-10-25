using System;
using CusomerManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace CusomerManagement.DTOs
{
	public class CustomerResponseDTO : CustomerDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public List<AddressResponseDTO> Addresses { get; set; }
    }
}

