using System;
using CustomerManagement.DTOs;

namespace CustomerManagement.Validators
{
	public interface ICustomerRequestValidator
    {
		bool doesAddressExist(CustomerRequestDTO customerRequest);
	}
}

