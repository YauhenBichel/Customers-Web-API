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
        private readonly ICustomerValidator customerValidator;


        public CustomerService(ILogger<CustomerService> logger,
            ICustomerRepository customerRepository,
            ICustomerValidator customerValidator)
		{
			this.logger = logger;
			this.customerRepository = customerRepository;
            this.customerValidator = customerValidator;
		}

        public Customer create(Customer customer)
        {
            return customerRepository.create(customer);
        }

        public Customer getById(int id)
        {
            return customerRepository.getById(id);
        }

        public IEnumerable<Customer> getAll(bool activeOnly)
        {
            return customerRepository.GetAll(activeOnly);
        }

        public void delete(int id)
        {
            customerRepository.delete(id);
        }

        public Customer update(Customer customer)
        {
            return customerRepository.update(customer);
        }
    }
}

