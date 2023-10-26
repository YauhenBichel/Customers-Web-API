using System;
using CusomerManagement.Models;
using System.ComponentModel.DataAnnotations;
using CusomerManagement.Validators;

namespace CusomerManagement.DTOs
{
	public abstract class CustomerDTO
	{
        [Required]
        [StringLength(Constants.CUSTOMER_TITLE_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Title { get; set; }
        [Required]
        [StringLength(Constants.CUSTOMER_FORENAME_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Forename { get; set; }
        [Required]
        [StringLength(Constants.CUSTOMER_SURNAME_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Surname { get; set; }
        [Required]
        [StringLength(Constants.CUSTOMER_EMAIL_ADDRESS_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(Constants.CUSTOMER_MOBILE_NUMBER_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string MobileNo { get; set; }
        public Boolean InActive { get; set; }
    }
}

