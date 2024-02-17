using MagicApartment_HousingAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MagicApartment_HousingAPI.Data
{
    public class ApartmentDBContext : DbContext
    {
        public ApartmentDBContext(DbContextOptions<ApartmentDBContext> options) : base(options) { }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Login> Users { get; set; }

    }
}
