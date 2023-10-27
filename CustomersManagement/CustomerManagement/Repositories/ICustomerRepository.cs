using System;
using CusomerManagement.Models;

namespace CusomerManagement.Repositories
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

