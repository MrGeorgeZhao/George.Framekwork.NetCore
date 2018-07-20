using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace George.Framekwork.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {

        [Route("test")]
        [HttpGet]
        public async Task<IActionResult> TestApi()
        {
            return Ok(new { name = "111", age = 2 });
        }

    }
}