using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityVeterinary.Models
{
    public class RecentActivity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public string? DateAdded { get; set; }
    }
}