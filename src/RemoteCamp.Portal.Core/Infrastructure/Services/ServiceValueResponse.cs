using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteCamp.Portal.Core.Infrastructure.Services
{
    public class ServiceValueResponse<TValue>
    {
        public ServiceValueResponse()
        {
            Errors = new List<ServiceResponseError>();
        }

        public TValue Value { get; set; }

        public DateTime CurrentDateTimeStap { get; set; }

        public IList<ServiceResponseError> Errors { get; set; }

        public bool IsSuccess => !Errors.Any();

        public bool ContainsErrorCode(ErrorCodes errorCode)
        {
            return Errors != null && Errors.Any(x => x.Code == errorCode);
        }

        public static ServiceValueResponse<TValue> Success(TValue value)
        {
            return new ServiceValueResponse<TValue>
            {
                Value = value,
                CurrentDateTimeStap = DateTime.UtcNow
            };
        }

        public static ServiceValueResponse<TValue> Error(ErrorCodes errorCode, string message)
        {
            return new ServiceValueResponse<TValue>
            {
                Errors = new List<ServiceResponseError>
                {
                    new ServiceResponseError
                    {
                        Code = errorCode,
                        Message = message
                    }
                }
            };
        }

        public static ServiceValueResponse<TValue> NotFound(string message = "Not Found")
        {
            return new ServiceValueResponse<TValue>
            {
                Errors = new List<ServiceResponseError>
                {
                    new ServiceResponseError
                    {
                        Code = ErrorCodes.NotFound,
                        Message = message
                    }
                }
            };
        }

        public static ServiceValueResponse<TValue> FromErrors(IList<ServiceResponseError> errors)
        {
            return new ServiceValueResponse<TValue>
            {
                Errors = errors
            };
        }
    }
}
