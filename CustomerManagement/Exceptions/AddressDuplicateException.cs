using System;
namespace CustomerManagement.Exceptions
{
    public sealed class AddressDuplicateException : Exception
    {
        public AddressDuplicateException(string message = "Address exists exception", string? localizerKey = null) : base(message)
        {
            Data.Add(AbstractExceptionHandlerMiddleware.LocalizationKey, message);
        }
    }
}

