using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class Baranggay
    {
        public int Id { get; set; }
        public string? DateAdded { get; set; }
        [Required]
        public string? BaranggayName { get; set; }
    }
}