using System;
using CustomerManagement.Controllers;
using CustomerManagement.DTOs;
using CustomerManagement.Exceptions;
using CustomerManagement.Models;

namespace CustomerManagement.Validators
{
    public class AddressValidator : IAddressValidator
    {
        private readonly ILogger<AddressValidator> logger;

        public AddressValidator(ILogger<AddressValidator> logger)
        {
            this.logger = logger;
        }

        public bool IsDuplicate(IEnumerable<Address> addresses)
        {
            return addresses != null && addresses.Count() > 0;
        }
    }
}
