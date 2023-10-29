using System;
using CustomerManagement.Controllers;
using CustomerManagement.Exceptions;
using CustomerManagement.Models;
using CustomerManagement.Repositories;
using CustomerManagement.Validators;

namespace CustomerManagement.Services
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

        public Customer Create(Customer customer)
        {
            if(customerValidator.Exists(customer))
            {
                logger.LogError("The same  customer exists");
                throw new CustomerDuplicateException();
            }

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
            if (customerValidator.Exists(customer))
            {
                logger.LogError("The same  customer exists");
                throw new CustomerDuplicateException();
            }

            return customerRepository.Update(customer);
        }
    }
}

