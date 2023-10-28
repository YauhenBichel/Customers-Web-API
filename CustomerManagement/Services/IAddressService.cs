using System;
using CustomerManagement.Models;

namespace CustomerManagement.Services
{
	public interface IAddressService
	{
        Address Create(int customerId, Address address);
        Address Update(int customerId, Address address);
        Address GetById(int customerId, int addressId);
        Address GetMainAddress(int customerId);
        IEnumerable<Address> GetAllByCustomerId(int customerId);
        void Delete(int addressId);
    }
}

