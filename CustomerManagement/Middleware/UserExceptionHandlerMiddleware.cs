using System;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System.Net;
using CustomerManagement.Exceptions;

namespace CustomerManagement.Middleware
{
	public class UserExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
    {
        public UserExceptionHandlerMiddleware(RequestDelegate next) : base(next)
        {
            
        }

        public override (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            HttpStatusCode code;
            switch (exception)
            {
                case MoreThanOneMainAddressException or NoMainAddressException:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            string message = exception.Data[LocalizationKey]?.ToString() ?? "Internal error";

            return (code, JsonConvert.SerializeObject(message));
        }
    }
}

