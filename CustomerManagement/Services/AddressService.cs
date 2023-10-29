using System;
using CustomerManagement.Controllers;
using CustomerManagement.Exceptions;
using CustomerManagement.Models;
using CustomerManagement.Repositories;
using CustomerManagement.Validators;

namespace CustomerManagement.Services
{
    public class AddressService : IAddressService
	{
        private readonly ILogger<AddressService> logger;
        private readonly IAddressRepository addressRepository;
        private readonly ICustomerService customerService;
        private readonly IAddressValidator addressValidator;

        public AddressService(ILogger<AddressService> logger,
            IAddressRepository addressRepository,
            ICustomerService customerService,
            IAddressValidator addressValidator)
		{
			this.logger = logger;
			this.addressRepository = addressRepository;
            this.customerService = customerService;
            this.addressValidator = addressValidator;
        }

        public Address Create(int customerId, Address address)
        {
            Customer dbCustomer = customerService.GetById(customerId);
            if(dbCustomer == null)
            {
                logger.LogError("Customer with Id='{}' not found", customerId);
                throw new CustomerNotFoundException();
            }

            IEnumerable<Address> addresses = dbCustomer.Addresses;

            if(addressValidator.IsDuplicate(address, addresses))
            {
                logger.LogError("The same address exists");
                throw new AddressDuplicateException();
            }

            addresses.Append(address);
            addressValidator.DoesOnlyOneMainAddressExist(addresses);

            Address dbAddress = addressRepository.Create(customerId, address);
            return dbAddress;
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
            if(!customerService.Exists(customerId))
            {
                logger.LogError("customer not found");
                return null;
            }

            IEnumerable<Address> addresses = GetAllByCustomerId(customerId);

            if (addressValidator.IsDuplicate(address, addresses))
            {
                logger.LogError("The same address exists");
                throw new AddressDuplicateException();
            }

            addressValidator.DoesOnlyOneMainAddressExist(addresses);

            return addressRepository.Update(address);
        }

        public Address UpdateMainAddress(int customerId, Address address)
        {
            if (!customerService.Exists(customerId))
            {
                logger.LogError("customer not found");
                return null;
            }

            if(address.IsMain)
            {
                Address oldMainAddress = GetMainAddress(customerId);
                oldMainAddress.IsMain = false;
                addressRepository.UpdateMainAddress(oldMainAddress, address);
            }
            else
            {
                IEnumerable<Address> addresses = GetAllByCustomerId(customerId);
                if(addresses.Count() == Constants.ADDRESS_MINIMUM_AMOUNT)
                {
                    logger.LogError("Attempt to mark address as not main for customer with ID = '{}'", customerId);
                    throw new NoMainAddressException();
                }
                else
                {
                    Address newMainAddress = addresses.OrderBy(dbAddress => dbAddress.CreatedDate)
                        .Where(dbAddress => dbAddress.Id != address.Id)
                        .FirstOrDefault();

                    if(newMainAddress == null)
                    {
                        logger.LogError("Not found 2d address for customer with ID = '{}'", customerId);
                        throw new NoMainAddressException();
                    }

                    newMainAddress.IsMain = true;
                    addressRepository.UpdateMainAddress(newMainAddress, address);
                }
            }

            return address;
        }

        public void Delete(int customerId, int addressId)
        {
            IEnumerable<Address> addresses = GetAllByCustomerId(customerId);
            if (addresses.Count() <= Constants.ADDRESS_MINIMUM_AMOUNT)
            {
                logger.LogError("The customer has only one address. The min number of addresses is {}. CustomerId is {}, addressId is {}",
                     Constants.ADDRESS_MINIMUM_AMOUNT, customerId, addressId);
                throw new MainAddressRemovingException();
            }

            Address dbAddress = GetById(customerId, addressId);
            if (dbAddress.IsMain)
            {
                logger.LogError("Main address could not be removed. CustomerId is {}, addressId is {}",
                     customerId, addressId);
                throw new MainAddressRemovingException();
            }

            addressRepository.Delete(customerId, addressId);
        }
    }
}

