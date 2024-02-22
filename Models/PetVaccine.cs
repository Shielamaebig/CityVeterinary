using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class PetVaccine
    {
        public int Id { get; set; }
        public string? DateAdded { get; set; }

        // PetInformation
        public int PetInformationId { get; set; }
        public virtual PetInformation? PetInformation { get; set; }
        public string? PetName { get; set; }
        public string? BreedType { get; set; }
        public string? PetType { get; set; }
        public string? Gender { get; set; }
        public string? Powner { get; set; }


        public string? DateVaxStart { get; set; }
        public string? DateVaxEnd { get; set; }

        //Vaccine
        public int VaccineId { get; set; }
        public virtual Vaccine? Vaccine { get; set; }
        public string? VaccineName { get; set; }


        // Veterinarian
        public int VeterinarianId { get; set; }
        public virtual Veterinarian? Veterinarian { get; set; }
        public string? VeterinarianName { get; set; }

        // Vaccinator
        public int VaccinatorId { get; set; }
        public virtual Vaccinator? Vaccinator { get; set; }
        public string? VaccinatorName { get; set; }

    }
}
