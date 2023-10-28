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

        public void Delete(int addressId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Address GetById(int addressId)
        {
            throw new NotImplementedException();
        }

        public Address Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}

