using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceFdrv.Controllers
{
    public class MathController : Controller
    {
        [Route("api/math/sum/{id?}")]
        public int Sum(int x, int y) => x + y;

        [Route("api/math/diff/{id?}")]
        public int Difference(int x, int y) => x - y;

        [Route("api/math/mult/{id?}")]
        public int Multiply(int x, int y) => x * y;

        [Route("api/math/div/{id?}")]
        public int Divide(int x, int y) => x / y;
    }
}