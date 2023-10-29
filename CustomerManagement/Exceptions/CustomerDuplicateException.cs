using System;
namespace CustomerManagement.Exceptions
{
    public sealed class CustomerDuplicateException : Exception
    {
        public CustomerDuplicateException(string message = "Customer exists exception", string? localizerKey = null) : base(message)
        {
            Data.Add(AbstractExceptionHandlerMiddleware.LocalizationKey, message);
        }
    }
}

