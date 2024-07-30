using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityVeterinary.Controllers
{
    public class PetInfoController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }

    }
}