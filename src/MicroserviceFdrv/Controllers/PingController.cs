using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; // AllowAnonymous

namespace MicroserviceFdrv.Controllers
{
    [Route("api/ping")]
    public class PingController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() {
            return Ok(ResponseResult.Success());
        }
    }
}