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

        public override bool Equals(object? obj)
        {
            return obj is CustomerResponseDTO dTO &&
                   Title == dTO.Title &&
                   Forename == dTO.Forename &&
                   Surname == dTO.Surname &&
                   EmailAddress == dTO.EmailAddress &&
                   MobileNo == dTO.MobileNo &&
                   InActive == dTO.InActive &&
                   Id == dTO.Id &&
                   EqualityComparer<List<AddressResponseDTO>>.Default.Equals(Addresses, dTO.Addresses);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Forename, Surname, EmailAddress, MobileNo, InActive, Id, Addresses);
        }
    }
}

