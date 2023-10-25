using System;
using CusomerManagement.Controllers;

namespace CusomerManagement.Services
{
	public class CustomerService: ICustomerService
	{
        private readonly ILogger<CustomerService> logger;
        private readonly ICustomerRepository customerRepository;

		public CustomerService(ILogger<CustomerService> logger, ICustomerRepository customerRepository)
		{
			this.logger = logger;
			this.customerRepository = customerRepository;
		}
	}
}

