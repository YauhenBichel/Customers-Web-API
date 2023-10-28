using System;
using CustomerManagement.Controllers;
using CustomerManagement.Models;
using CustomerManagement.Repositories;
using CustomerManagement.Validators;

namespace CustomerManagement.Services
{
    public class AddressService : IAddressService
	{
        private readonly ILogger<AddressService> logger;
        private readonly IAddressRepository addressRepository;


        public AddressService(ILogger<AddressService> logger,
            IAddressRepository addressRepository)
		{
			this.logger = logger;
			this.addressRepository = addressRepository;
		}

        public Address Create(int customerId, Address address)
        {
            throw new NotImplementedException();
        }

        public void Delete(int customerId, int addressId)
        {
            addressRepository.Delete(customerId, addressId);
        }

        public IEnumerable<Address> GetAllByCustomerId(int customerId)
        {
            return addressRepository.GetAllByCustomerId(customerId);
        }

        public Address GetById(int customerId, int addressId)
        {
            return addressRepository.GetById(customerId, addressId);
        }

        public Address GetMainAddress(int customerId)
        {
            throw new NotImplementedException();
        }

        public Address Update(int customerId, Address address)
        {
            throw new NotImplementedException();
        }
    }
}

