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

        public override bool Equals(object? obj)
        {
            return obj is CustomerRequestDTO dTO &&
                   Title == dTO.Title &&
                   Forename == dTO.Forename &&
                   Surname == dTO.Surname &&
                   EmailAddress == dTO.EmailAddress &&
                   MobileNo == dTO.MobileNo &&
                   InActive == dTO.InActive &&
                   EqualityComparer<List<AddressRequestDTO>>.Default.Equals(Addresses, dTO.Addresses);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Forename, Surname, EmailAddress, MobileNo, InActive, Addresses);
        }
    }
}
