using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Dto
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string? DateAdded { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? ContactNumber { get; set; }
        public int BaranggayId { get; set; }
        public string? PetName { get; set; }
        public string? Markings { get; set; }
        public string? Gender { get; set; }
        public int? PetTypeId { get; set; }
        public string? PetDateOfBirth { get; set; }
        public int BreedTypeId { get; set; }
        public string? AppointmentDate { get; set; }
        public string? AppointmentTime { get; set; }
        public string? UniqueCode { get; set; }
    }
}