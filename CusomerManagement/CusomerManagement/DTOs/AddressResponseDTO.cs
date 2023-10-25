using System;
using System.ComponentModel.DataAnnotations;
using CusomerManagement.Validators;

namespace CusomerManagement.DTOs
{
	public class AddressResponseDTO : AddressRequestDTO
	{
        [Required]
        public int Id { get; set; }
    }
}

