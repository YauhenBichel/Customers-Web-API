using System;
namespace CustomerManagement.Exceptions
{
    public sealed class MoreThanOneMainAddressException : Exception
    {
        public MoreThanOneMainAddressException(string message = "More than one main address exception", string? localizerKey = null) : base(message)
        {
            Data.Add(AbstractExceptionHandlerMiddleware.LocalizationKey, message);
        }
    }
}

