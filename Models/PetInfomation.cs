using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class PetInformation
    {
        public int Id { get; set; }
        public Guid PetInfoGuid { get; set; }
        public virtual PetOwner? PetOwner { get; set; }
        public int PetOwnerId { get; set; }
        public virtual PetType? PetType { get; set; }
        public int? PetTypeId { get; set; }
        public virtual BreedType? BreedType { get; set; }
        public int BreedTypeId { get; set; }
        public string? PetName { get; set; }
        public string? Markings { get; set; }
        public string? Species { get; set; }
        public string? Gender { get; set; }
        public string? DateOfBirth { get; set; }
        public string? TagNumber { get; set; }
        public string? DateRegister { get; set; }
        public string? OrNumber { get; set; }

    }
}