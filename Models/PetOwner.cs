using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class PetOwner
    {
        public int Id { get; set; }
        public string? DateAdded { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? ContactNumber { get; set; }
        public int BaranggayId { get; set; }
        public virtual Baranggay? Baranggay { get; set; }
        public string? BaranggayName { get; set; }
        public string? FileExtension { get; set; }
        public string? ImagePath { get; set; }
        public string? AddedBy { get; set; }

    }
}