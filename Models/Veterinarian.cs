using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class Veterinarian
    {
        public int Id { get; set; }
        public string? Vaccinator { get; set; }
        public string? DateAdded { get; set; }
    }
}
