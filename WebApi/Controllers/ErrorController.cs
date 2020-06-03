using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/Error")]
        public IActionResult Error() => Problem();

        [HttpGet("Test")]
        public void Test() => throw new Exception("Test");
    }
}
