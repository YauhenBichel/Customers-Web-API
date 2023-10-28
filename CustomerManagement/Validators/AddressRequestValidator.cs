using System;
using CustomerManagement.Controllers;
using CustomerManagement.DTOs;

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
            if(mainAddressesAmount == 0)
            {
                logger.LogError("No main address");
                return false;
            }
            if (mainAddressesAmount > 1)
            {
                logger.LogError("More than 1 main address");
                return false;
            }

            return true;

        }
    }
}
