using System;
using CusomerManagement.Models;

namespace CusomerManagement.Services
{
	public interface ICustomerService
	{
        Customer create(Customer customer);
        Customer update(Customer customer);
        Customer getById(int id);
        IEnumerable<Customer> getAll(bool activeOnly);
        void delete(int id);
    }
}

