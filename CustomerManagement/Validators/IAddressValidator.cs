using System;
using CustomerManagement.DTOs;
using CustomerManagement.Models;

namespace CustomerManagement.Validators
{
	public interface IAddressValidator
    {
		bool IsDuplicate(Address address, IEnumerable<Address> addresses);
        bool DoesOnlyOneMainAddressExist(IEnumerable<Address> addresses);
    }
}

