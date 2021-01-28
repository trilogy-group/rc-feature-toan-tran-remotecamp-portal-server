using Microsoft.AspNetCore.Http;
using RestSharp.Extensions;

namespace RemoteCamp.Portal.Web.Utils
{
    static class FormFileExtensions
    {
        public static byte[] ReadBytes(this IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                return null;
            }

            using (var stream = formFile.OpenReadStream())
            {
                return stream.ReadAsBytes();
            }
        }
    }
}
