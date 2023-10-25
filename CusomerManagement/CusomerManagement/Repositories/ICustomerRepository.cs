using System;
using CusomerManagement.Models;

namespace CusomerManagement.Repositories
{
	public interface ICustomerRepository
	{
        Customer create(Customer customer);
		Customer getById(int customerId);
		IEnumerable<Customer> GetAll(bool activeOnly);
		void delete(int customerId);
	}
}

