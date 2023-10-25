using System;
using System.Reflection.Metadata;
using CusomerManagement.Controllers;
using CusomerManagement.Models;
using CusomerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CusomerManagement
{
	public class CustomerRepository : ICustomerRepository
	{
        private readonly ILogger<CustomerRepository> logger;
        private readonly DbContext dbContext;

        public CustomerRepository(ILogger<CustomerRepository> logger, DbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public List<Customer> GetCustomers()
		{
            using (dbContext)
            {
                return dbContext.Customers
                    .Where(b => b.Rating > 3)
                    .OrderBy(b => b.Url)
                    .ToList();
            }
        }

        public List<Customer> GetActiveCustomers()
        {
            using (dbContext)
            {
                return dbContext.Customers
                    .Where(b => b.IsActive == true)
                    .OrderBy(b => b.Id)
                    .ToList();
            }
        }

        public async Task<ActionResult<Customer>> addCustomer(Customer customer)
        {
            using (dbContext)
            {
                dbContext.Customers.Add(customer);
                return await dbContext.SaveChangesAsync();
            }
        }
    }
}

