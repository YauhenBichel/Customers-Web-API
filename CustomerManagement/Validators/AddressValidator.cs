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

        public bool IsDuplicate(Address newAddress, IEnumerable<Address> addresses)
        {
            return addresses.Select(address => address.Equals(newAddress)).Any();
        }

        public bool DoesOnlyOneMainAddressExist(IEnumerable<Address> addresses)
        {
            int mainAddressesAmount = addresses.Where(address => address.IsMain).Count();
            if (addresses.Count() > 1 && mainAddressesAmount == 0)
            {
                logger.LogError("No main address");
                throw new NoMainAddressException();
            }
            if (addresses.Count() > 1 && mainAddressesAmount > 1)
            {
                logger.LogError("More than 1 main address");
                throw new MoreThanOneMainAddressException();
            }

            return true;

        }
    }
}
