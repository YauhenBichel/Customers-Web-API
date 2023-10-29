using System;
using CustomerManagement.DTOs;
using CustomerManagement.Models;

namespace CustomerManagement.Validators
{
	public interface ICustomerValidator
    {
		bool Exists(Customer customer);
    }
}

