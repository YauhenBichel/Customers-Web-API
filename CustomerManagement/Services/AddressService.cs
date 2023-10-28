﻿using System;
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
            IEnumerable<Address> addresses = GetAllByCustomerId(customerId);
            if(addresses.Count() <= Constants.ADDRESS_MINIMUM_AMOUNT)
            {
                logger.LogError("The customer has only one address. The min number of addresses is {}. CustomerId is {}, addressId is {}",
                     Constants.ADDRESS_MINIMUM_AMOUNT, customerId, addressId);
                //throw new Exception();
                return;
            }

            Address dbAddress = GetById(customerId, addressId);
            if (dbAddress.IsMain)
            {
                logger.LogError("Main address could not be removed. CustomerId is {}, addressId is {}",
                     customerId, addressId);
                //throw new Exception();
                return;
            }

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
            IEnumerable<Address> addresses = addressRepository.GetAllByCustomerId(customerId);
            if(addresses.Count() == 1)
            {
                return addresses.First();
            }
            else
            {
                return addresses.Where(address => address.IsMain).First();
            }
        }

        public Address Update(int customerId, Address address)
        {
            throw new NotImplementedException();
        }
    }
}

