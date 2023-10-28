using System;
using CustomerManagement.Controllers;
using CustomerManagement.Models;
using CustomerManagement.Repositories;
using CustomerManagement.Validators;

namespace CustomerManagement.Services
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

        public Customer Create(Customer customer)
        {
            if(customer.Addresses.Count() == 1 && !customer.Addresses[0].IsMain)
            {
                customer.Addresses[0].IsMain = true;
            }

            return customerRepository.Create(customer);
        }

        public Customer GetById(int id)
        {
            return customerRepository.GetById(id);
        }

        public IEnumerable<Customer> GetAll(bool activeOnly)
        {
            return customerRepository.GetAll(activeOnly);
        }

        public void Delete(int id)
        {
            customerRepository.Delete(id);
        }

        public Customer Update(Customer customer)
        {
            return customerRepository.Update(customer);
        }
    }
}

