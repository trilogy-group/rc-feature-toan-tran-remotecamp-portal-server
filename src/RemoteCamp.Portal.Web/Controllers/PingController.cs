using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return "I'm alive!";
        }
    }
}
