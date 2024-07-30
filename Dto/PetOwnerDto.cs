using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityVeterinary.Models;

namespace CityVeterinary.Dto
{
    public class PetOwnerDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
                public string? BaranggayName { get; set; }

        public string? ContactNumber { get; set; }
        public int BaranggayId { get; set; }
    }
}