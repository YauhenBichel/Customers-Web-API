using System;
using CustomerManagement.Models;

namespace CustomerManagement.Repositories
{
	public interface IAddressRepository
	{
        Address Create(int customerId, Address address);
        Address Update(Address address);
		Address UpdateMainAddress(Address oldMainAddress, Address newMainAddress);
        Address GetById(int customerId, int addressId);
		IEnumerable<Address> GetAllByCustomerId(int customerId);
		void Delete(int customerId, int addressId);
	}
}

