using System;
namespace CustomerManagement.Exceptions
{
    public sealed class MainAddressRemovingException : Exception
    {
        public MainAddressRemovingException(string message = "customer needs at least one address", string? localizerKey = null) : base(message)
        {
            Data.Add(AbstractExceptionHandlerMiddleware.LocalizationKey, message);
        }
    }
}

