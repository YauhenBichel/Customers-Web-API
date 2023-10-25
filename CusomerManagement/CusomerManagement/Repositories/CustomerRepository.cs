using System;
using System.Reflection.Metadata;
using CusomerManagement.Controllers;
using CusomerManagement.Models;
using CusomerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CusomerManagement.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
        private readonly ILogger<CustomerRepository> logger;
        private readonly CustomerContext dbContext;

        public CustomerRepository(ILogger<CustomerRepository> logger, CustomerContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public Customer create(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return customer;
        }

        public Customer getById(int customerId)
        {
            return dbContext.Customers
                .Where(customer => customer.Id == customerId)
                .FirstOrDefault();
        }

        public IEnumerable<Customer> GetAll(bool activeOnly)
        {
            if (activeOnly)
            {
                return dbContext.Customers
                    .Where(customer => customer.IsActive == activeOnly)
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
    }
}

