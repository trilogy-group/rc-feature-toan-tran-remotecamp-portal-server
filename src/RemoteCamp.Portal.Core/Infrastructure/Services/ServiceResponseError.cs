namespace RemoteCamp.Portal.Core.Infrastructure.Services
{
    public enum ErrorCodes
    {
        NotFound,
        InvalidGoogleToken,
        UserWasNotFound,
        UserRoleWasNotDetermined,
        RcXoIdNotExist,
        InvalidOperation,
        BadRequest,
        InvalidApiKey
    }

    public class ServiceResponseError
    {
        public ErrorCodes Code { get; set; }

        public string Message { get; set; }
    }
}
