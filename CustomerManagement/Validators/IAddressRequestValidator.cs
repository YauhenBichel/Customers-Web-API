using System;
using CustomerManagement.DTOs;

namespace CustomerManagement.Validators
{
	public interface IAddressRequestValidator
    {
		bool DoesAnyAddressExist(IEnumerable<AddressRequestDTO> addressRequests);
        bool DoesDuplicatesExist(IEnumerable<AddressRequestDTO> addressRequests);
        bool DoesOnlyOneMainAddressExist(IEnumerable<AddressRequestDTO> addressRequests);
    }
}

