﻿using System;
using System.ComponentModel.DataAnnotations;
using CusomerManagement.Validators;

namespace CusomerManagement.Models
{
	public class Customer : AuditEntity
    {
        public int Id { get; set; }
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
        public string EmailAdress { get; set; }
        [Required]
        [StringLength(Constants.CUSTOMER_MOBILE_NUMBER_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string MobileNo { get; set; }
        public Boolean IsActive { get; set; }
		public List<Address> Addresses { get; set; }
	}
}

