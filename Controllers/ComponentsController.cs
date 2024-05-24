using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityVeterinary.Controllers
{
    public class ComponentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PetTypes()
        {
            return View();
        }
        public IActionResult BreedTypes()
        {
            return View();
        }
        public IActionResult ServiceType()
        {
            return View();
        }
        public IActionResult VaccineType() 
        {
            return View();
        }
        public IActionResult Vaccinator()
        {
            return View();
        }
        public IActionResult Veterinarian(){
            return View();
        }
    }
}