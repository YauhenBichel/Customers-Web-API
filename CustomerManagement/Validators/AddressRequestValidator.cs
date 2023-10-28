using System;
using CustomerManagement.Controllers;
using CustomerManagement.DTOs;
using CustomerManagement.Exceptions;

namespace CustomerManagement.Validators
{
    public class AddressRequestValidator : IAddressRequestValidator
    {
        private readonly ILogger<AddressRequestValidator> logger;

        public AddressRequestValidator(ILogger<AddressRequestValidator> logger)
        {
            this.logger = logger;
        }

        public bool doesAddressExist(IEnumerable<AddressRequestDTO> addressRequests)
        {
            return addressRequests != null && addressRequests.Count() > 0;
        }

        public bool doesOnlyOneMainAddressExist(IEnumerable<AddressRequestDTO> addressRequests)
        {
            if(!doesAddressExist(addressRequests))
            {
                return false;
            }

            int mainAddressesAmount = addressRequests.Where(address => address.IsMain).Count();
            if(addressRequests.Count() > 1 && mainAddressesAmount == 0)
            {
                logger.LogError("No main address");
                throw new NoMainAddressException();
            }
            if (addressRequests.Count() > 1 && mainAddressesAmount > 1)
            {
                logger.LogError("More than 1 main address");
                throw new MoreThanOneMainAddressException();
            }

            return true;

        }
    }
}
