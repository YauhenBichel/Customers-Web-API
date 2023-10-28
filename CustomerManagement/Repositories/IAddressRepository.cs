using System;
using CustomerManagement.Models;

namespace CustomerManagement.Repositories
{
	public interface IAddressRepository
	{
        Address Create(Address address);
        Address Update(Address address);
        Address GetById(int addressId);
		IEnumerable<Address> GetAll();
		void Delete(int addressId);
	}
}

