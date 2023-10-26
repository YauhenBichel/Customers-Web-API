using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using CusomerManagement.Validators;
using Microsoft.EntityFrameworkCore;

namespace CusomerManagement.Models
{
    [Index(nameof(EmailAddress), IsUnique = true)]
    [Index(nameof(MobileNo), IsUnique = true)]
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

