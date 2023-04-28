using Day1API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountRequestsController : ControllerBase
    {
        [HttpGet]
        public int GetNoOfRequests ()
        {
            return Counter.Count;

        }
    }
}
