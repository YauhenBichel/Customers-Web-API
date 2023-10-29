using System;
namespace CustomerManagement.Exceptions
{
    public sealed class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message = "Customer not found exception", string? localizerKey = null) : base(message)
        {
            Data.Add(AbstractExceptionHandlerMiddleware.LocalizationKey, message);
        }
    }
}

