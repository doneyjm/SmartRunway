using Microsoft.EntityFrameworkCore;
using SmartRunwayApi.Data.Entities;

namespace SmartRunwayApi.Data
{
    public class AirportDbContext : DbContext
    {
        public AirportDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Runway> Runways { get; set; }

        public DbSet<Landing> Landings { get; set; }

        public DbSet<TakeOff> TakeOffs { get; set; }
    }
}