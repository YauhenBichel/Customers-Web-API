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

        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                   CreatedDate == customer.CreatedDate &&
                   UpdatedDate == customer.UpdatedDate &&
                   Id == customer.Id &&
                   Title == customer.Title &&
                   Forename == customer.Forename &&
                   Surname == customer.Surname &&
                   EmailAddress == customer.EmailAddress &&
                   MobileNo == customer.MobileNo &&
                   InActive == customer.InActive &&
                   EqualityComparer<List<Address>>.Default.Equals(Addresses, customer.Addresses);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(CreatedDate);
            hash.Add(UpdatedDate);
            hash.Add(Id);
            hash.Add(Title);
            hash.Add(Forename);
            hash.Add(Surname);
            hash.Add(EmailAddress);
            hash.Add(MobileNo);
            hash.Add(InActive);
            hash.Add(Addresses);
            return hash.ToHashCode();
        }
    }
}

