using System;
using System.Net;
using System.Reflection.Metadata;
using CustomerManagement.Controllers;
using CustomerManagement.Models;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Repositories
{
    public class AddressDbContextRepository : IAddressRepository
	{
        private readonly ILogger<AddressDbContextRepository> logger;
        private readonly CustomerMngmContext dbContext;

        public AddressDbContextRepository(ILogger<AddressDbContextRepository> logger, CustomerMngmContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public Address Create(int customerId, Address address)
        {
            Customer customer = dbContext.Customers
                .Include(c => c.Addresses)
                .Where(customer => customer.Id == customerId)
                .FirstOrDefault();

            if (customer == null)
            {
                return null;
            }

            customer.Addresses.Add(address);

            dbContext.SaveChanges();
            return address;
        }

        public Address Update(Address address)
        {
            dbContext.Addresses.Update(address);
            dbContext.SaveChanges();
            return address;
        }

        public IEnumerable<Address> GetAllByCustomerId(int customerId)
        {
            Customer customer = dbContext.Customers
                .Include(c => c.Addresses)
                .Where(customer => customer.Id == customerId)
                .FirstOrDefault();

            if (customer == null)
            {
                return null;
            }

            return customer.Addresses.ToList();
        }

        public Address GetById(int customerId, int addressId)
        {
            IEnumerable<Address> addresses = GetAllByCustomerId(customerId);

            if (addresses == null)
            {
                return null;
            }

            return addresses.Where(address => address.Id == addressId)
                .FirstOrDefault();
        }

        public void Delete(int customerId, int addressId)
        {
            Customer customerForRemoving = dbContext.Customers
                .Include(c => c.Addresses)
                .Where(customer => customer.Id == customerId)
                .FirstOrDefault();

            if (customerForRemoving != null)
            {
                Address addressForRemoving = customerForRemoving.Addresses
                .Where(address => address.Id == addressId)
                .FirstOrDefault();

                if (addressForRemoving != null)
                {
                    dbContext.Addresses.Remove(addressForRemoving);
                    dbContext.SaveChanges();
                }
            }
        }

        public Address UpdateMainAddress(Address oldMainAddress, Address newMainAddress)
        {
            dbContext.Addresses.Update(oldMainAddress);
            dbContext.Addresses.Update(newMainAddress);
            dbContext.SaveChanges();
            return newMainAddress;
        }
    }
}

