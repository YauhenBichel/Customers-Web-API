using System;
using System.Reflection.Metadata;
using CusomerManagement.Controllers;
using CusomerManagement.Models;
using CusomerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CusomerManagement.Repositories
{
	public class CustomerDbContextRepository : ICustomerRepository
	{
        private readonly ILogger<CustomerDbContextRepository> logger;
        private readonly CustomerMngmContext dbContext;

        public CustomerDbContextRepository(ILogger<CustomerDbContextRepository> logger, CustomerMngmContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public Customer Create(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return customer;
        }

        public Customer GetById(int customerId)
        {
            return dbContext.Customers
                .Include(c => c.Addresses)
                .Where(customer => customer.Id == customerId)
                .FirstOrDefault();
        }

        public IEnumerable<Customer> GetAll(bool activeOnly)
        {
            if (activeOnly)
            {
                return dbContext.Customers
                    .Where(customer => customer.InActive == activeOnly)
                    .Include(c => c.Addresses)
                    .OrderBy(customer => customer.Id)
                    .ToList();
            }
            else
            {
                return dbContext.Customers
                    .OrderBy(customer => customer.Id)
                    .ToList();
            }
        }

        public void Delete(int customerId)
        {
            var customerForRemoving = this.GetById(customerId);

            if (customerForRemoving != null)
            {
                dbContext.Customers.Remove(customerForRemoving);
                dbContext.SaveChanges();
            }
        }

        public Customer Update(Customer customer)
        {
            dbContext.Customers.Update(customer);
            dbContext.SaveChanges();
            return customer;
        }
    }
}

