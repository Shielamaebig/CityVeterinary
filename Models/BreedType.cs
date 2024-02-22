using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class BreedType
    {
        public int Id { get; set; }
        public string? DateAdded { get; set; }
        public virtual PetType? PetType { get; set; }
        public int PetTypeId { get; set; }
    }
}
