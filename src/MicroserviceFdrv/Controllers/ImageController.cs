using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceFdrv.Controllers
{
    public class ImageController : Controller
    {
        [Route("addimg")]
        public IActionResult AddTodb()
        {
            return View();
        }
    }
}