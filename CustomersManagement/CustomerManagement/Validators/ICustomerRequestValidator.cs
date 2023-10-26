using System;
using CusomerManagement.DTOs;

namespace CusomerManagement.Validators
{
	public interface ICustomerRequestValidator
    {
		bool doesAddressExist(CustomerRequestDTO customerRequest);
	}
}

