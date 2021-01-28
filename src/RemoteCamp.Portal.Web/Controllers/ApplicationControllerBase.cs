using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Web.Controllers
{
    public class ApplicationControllerBase : Controller
    {
        protected ActionResult<TValue> CreateResponse<TValue>(ServiceValueResponse<TValue> serviceResponse)
        {
            if (serviceResponse.IsSuccess)
            {
                return serviceResponse.Value;
            }

            var error = serviceResponse.Errors.FirstOrDefault();
            if (error.Code == ErrorCodes.NotFound)
            {
                return NotFound(error.Message);
            }

            throw new ApplicationException();
        }

        protected ActionResult CreateResponse(ServiceResponse serviceResponse)
        {
            if (serviceResponse.IsSuccess)
            {
                return Ok(serviceResponse);
            }

            var error = serviceResponse.Errors.FirstOrDefault();
            if (error.Code == ErrorCodes.NotFound)
            {
                return NotFound(error.Message);
            }

            if (error.Code == ErrorCodes.BadRequest)
            {
                return BadRequest(error.Message);
            }

            if (error.Code == ErrorCodes.InvalidOperation)
            {
                return BadRequest(error.Message);
            }

            throw new ApplicationException(error.Message);
        }
    }
}
