﻿using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CustomerManagement.Models
{
    public class CustomerMngmContext : DbContext
	{
		public CustomerMngmContext(DbContextOptions<CustomerMngmContext> options) : base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Address> Addresses { get; set; }
        
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((AuditEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add constraints
            //in-memory database does not support constraints

            base.OnModelCreating(modelBuilder);
        }
    }
}

