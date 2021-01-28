using System.Collections.Generic;
using System.Linq;

namespace RemoteCamp.Portal.Core.Infrastructure.Services
{
    public class ServiceResponse
    {
        public IList<ServiceResponseError> Errors { get; set; } = new List<ServiceResponseError>();

        public bool IsSuccess => !Errors.Any();

        public bool ContainsErrorCode(ErrorCodes errorCode)
        {
            return Errors != null && Errors.Any(x => x.Code == errorCode);
        }

        public static ServiceResponse Success()
        {
            return new ServiceResponse();
        }

        public static ServiceResponse Error(ErrorCodes errorCode, string message)
        {
            return new ServiceResponse
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

        public static ServiceResponse NotFound(string message = "Not Found")
        {
            return new ServiceResponse
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

        public static ServiceResponse FromErrors(IList<ServiceResponseError> errors)
        {
            return new ServiceResponse
            {
                Errors = errors
            };
        }
    }
}
