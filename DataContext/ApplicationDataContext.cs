using Microsoft.EntityFrameworkCore;
using CityVeterinary.Models;

namespace CityVeterinary.DataContext
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }


        public DbSet<Baranggay> Baranggays => Set<Baranggay>();
        public DbSet<PetOwner> PetOwners => Set<PetOwner>();
        public DbSet<CityVetEncoder> CityVetEncoders => Set<CityVetEncoder>();
        public DbSet<PetType> PetTypes => Set<PetType>();
        public DbSet<BreedType> BreedTypes => Set<BreedType>();
        public DbSet<PetInformation> PetInformations => Set<PetInformation>();
        public DbSet<PetVaccine> PetVaccines => Set<PetVaccine>();
        public DbSet<Veterinarian> Veterinarians => Set<Veterinarian>();
        public DbSet<Vaccine> Vaccines => Set<Vaccine>();
        public DbSet<RecentActivity> RecentActivities => Set<RecentActivity>();
        public DbSet<Vaccinator> Vaccinators => Set<Vaccinator>();

    }
}