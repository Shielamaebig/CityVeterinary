using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityVeterinary.Controllers
{
    public class EncoderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}