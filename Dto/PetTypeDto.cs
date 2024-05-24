using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Dto
{
    public class PetTypeDto
    {
        public int Id { get; set; }
        public string? DateAdded { get; set; }
        public string? PetTypeName { get; set; }
    }
}