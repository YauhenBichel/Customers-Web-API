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
    }
}

