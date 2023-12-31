﻿using System;
using CustomerManagement.Models;

namespace CustomerManagement.Services
{
	public interface ICustomerService
	{
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        Customer GetById(int id);
        IEnumerable<Customer> GetAll(bool activeOnly);
        bool Exists(int id);
        void Delete(int id);
    }
}

