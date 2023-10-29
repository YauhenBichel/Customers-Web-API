using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using CustomerManagement.Validators;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Models
{
    public class Customer : AuditEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public Boolean InActive { get; set; }
		public List<Address> Addresses { get; set; }
	}
}

