using System;
using CustomerManagement.DTOs;

namespace CustomerManagement.Validators
{
	public interface IAddressRequestValidator
    {
		bool doesAddressExist(IEnumerable<AddressRequestDTO> addressRequests);
        bool doesOnlyOneMainAddressExist(IEnumerable<AddressRequestDTO> addressRequests);
    }
}

