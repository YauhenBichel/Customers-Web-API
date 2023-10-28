using System;
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

        public Address Create(Address address)
        {
            throw new NotImplementedException();
        }

        public void Delete(int customerId, int addressId)
        {
            throw new NotImplementedException();
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

        public Address Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}

