using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class PetType
    {
        public int Id { get; set; }
        public Guid PetTypeGuid { get; set; }
        public string? DateAdded { get; set; }
        public string? PetTypeName { get; set; }
    }
}