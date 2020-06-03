using EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public TestContext TestContext;

        public UserController(TestContext testContext)
        {
            TestContext = testContext ?? throw new ArgumentNullException(nameof(testContext));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await TestContext.User.ToListAsync();
        }
    }
}
