using System;
using CustomerManagement.Models;

namespace CustomerManagement.Repositories
{
	public interface ICustomerRepository
	{
        Customer Create(Customer customer);
		Customer Update(Customer customer);
		Customer GetById(int customerId);
		IEnumerable<Customer> GetAll(bool activeOnly);
		void Delete(int customerId);
	}
}

