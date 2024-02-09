using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class PetVaccine
    {
        public int Id { get; set; }
        public string? Manufacturer { get; set; }
        public string? LotNumber { get; set; }
        public string? DateAdded { get; set; }
        public string? VaccineName { get; set; }
    }
}
