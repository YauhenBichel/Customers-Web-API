using System;
using CustomerManagement.DTOs;

namespace CustomerManagement.Validators
{
    public class CustomerRequestValidator : ICustomerRequestValidator
    {
        public CustomerRequestValidator()
        {
        }

        public bool doesAddressExist(CustomerRequestDTO customerRequest)
        {
            return customerRequest != null && customerRequest.Addresses != null &&
                customerRequest.Addresses.Count > 0;
        }
    }
}
