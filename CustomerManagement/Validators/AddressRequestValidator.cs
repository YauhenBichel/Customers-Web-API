using System;
using System.Linq;
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

        public bool DoesAnyAddressExist(IEnumerable<AddressRequestDTO> addressRequests)
        {
            return addressRequests != null && addressRequests.Count() > 0;
        }

        public bool DoesDuplicatesExist(IEnumerable<AddressRequestDTO> addressRequests)
        {
            ISet<AddressRequestDTO> addressSet = new HashSet<AddressRequestDTO>();

            foreach (var address in addressRequests)
            {
                if(!addressSet.Contains(address))
                {
                    addressSet.Add(address);
                }
                else
                {
                    logger.LogError("Duplicate is {}", address);
                    return true;
                }
            }

            return false;
        }

        public bool DoesOnlyOneMainAddressExist(IEnumerable<AddressRequestDTO> addressRequests)
        {
            if(!DoesAnyAddressExist(addressRequests))
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
