using System;
using CustomerManagement.DTOs;
using CustomerManagement.Models;

namespace CustomerManagement.Validators
{
    public class CustomerValidator : ICustomerValidator
    {
        public bool Exists(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

