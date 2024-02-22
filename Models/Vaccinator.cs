using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class Vaccinator
    {
        public int Id { get; set; }
        public string? DateAdded { get; set; }
        public string? FullName { get; set; }
    }
}