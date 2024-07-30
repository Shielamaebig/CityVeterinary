using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Dto
{
    public class PetInfoDto
    {
          public int Id { get; set; }

        public string? DateAdded { get; set; }
        public int? PetTypeId { get; set; }
        public int BreedTypeId { get; set; }
        public string? BreedTypeName { get; set; }
        public string? PetName { get; set; }
        public string? Markings { get; set; }
        public string? Species { get; set; }
        public string? Gender { get; set; }
        public string? DateOfBirth { get; set; }
        public string? TagNumber { get; set; }
        public string? DateRegister { get; set; }
        public string? OrNumber { get; set; }
        public string? AddedBy { get; set; }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? ContactNumber { get; set; }
        public int BaranggayId { get; set; }

    }
}