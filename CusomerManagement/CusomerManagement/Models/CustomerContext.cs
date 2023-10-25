using System;

using Microsoft.EntityFrameworkCore;

namespace CusomerManagement.Models
{
    public class CustomerContext : DbContext
	{
		public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Address> Addresses { get; set; }
	}
}

