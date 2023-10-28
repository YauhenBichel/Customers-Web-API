using System;
using System.ComponentModel.DataAnnotations;
using CustomerManagement.Validators;

namespace CustomerManagement.DTOs
{
	public class AddressResponseDTO : AddressRequestDTO
	{
        [Required]
        public int Id { get; set; }
    }
}

