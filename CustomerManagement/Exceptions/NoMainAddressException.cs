using System;
namespace CustomerManagement.Exceptions
{
    public sealed class NoMainAddressException : Exception
    {
        public NoMainAddressException(string message = "No main address exception", string? localizerKey = null) : base(message)
        {
            Data.Add(AbstractExceptionHandlerMiddleware.LocalizationKey, message);
        }
    }
}

