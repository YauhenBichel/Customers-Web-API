using System;
using CusomerManagement.Controllers;
using CusomerManagement.Models;
using CusomerManagement.Repositories;
using CusomerManagement.Validators;

namespace CusomerManagement.Services
{
	public class CustomerService: ICustomerService
	{
        private readonly ILogger<CustomerService> logger;
        private readonly ICustomerRepository customerRepository;


        public CustomerService(ILogger<CustomerService> logger,
            ICustomerRepository customerRepository)
		{
			this.logger = logger;
			this.customerRepository = customerRepository;
		}

        public Customer create(Customer customer)
        {
            return customerRepository.Create(customer);
        }

        public Customer getById(int id)
        {
            return customerRepository.GetById(id);
        }

        public IEnumerable<Customer> getAll(bool activeOnly)
        {
            return customerRepository.GetAll(activeOnly);
        }

        public void delete(int id)
        {
            customerRepository.Delete(id);
        }

        public Customer update(Customer customer)
        {
            return customerRepository.Update(customer);
        }
    }
}

