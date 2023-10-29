using System;
using CustomerManagement.DTOs;
using CustomerManagement.Models;

namespace CustomerManagement.Validators
{
	public interface IAddressValidator
    {
		bool IsDuplicate(IEnumerable<Address> addresses);
    }
}

