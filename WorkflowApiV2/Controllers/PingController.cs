using System;
using Microsoft.AspNetCore.Mvc;

namespace WorkflowApi.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        public PingController()
        {
        }


        [HttpGet]
        public IActionResult Ping()
        {
            return new ObjectResult("pong");
        }
    }
}
