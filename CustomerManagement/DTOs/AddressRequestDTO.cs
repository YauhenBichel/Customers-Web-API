using System;
using System.ComponentModel.DataAnnotations;
using CustomerManagement.Validators;

namespace CustomerManagement.DTOs
{
	public class AddressRequestDTO
	{
        [Required]
        [StringLength(Constants.ADDRESS_ADDRESS_LINE_1_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string AddressLine1 { get; set; }
        [StringLength(Constants.ADDRESS_ADDRESS_LINE_2_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(Constants.ADDRESS_TOWN_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Town { get; set; }
        [StringLength(Constants.ADDRESS_COUNTRY_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Country { get; set; }
        [Required]
        [StringLength(Constants.ADDRESS_POSTCODE_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Postcode { get; set; }
        public bool IsMain { get; set; }

        //without isMain
        public override bool Equals(object? obj)
        {
            return obj is AddressRequestDTO dTO &&
                   AddressLine1 == dTO.AddressLine1 &&
                   AddressLine2 == dTO.AddressLine2 &&
                   Town == dTO.Town &&
                   Country == dTO.Country &&
                   Postcode == dTO.Postcode;
        }

        //without isMain
        public override int GetHashCode()
        {
            return HashCode.Combine(AddressLine1, AddressLine2, Town, Country, Postcode);
        }
    }
}

