using Network.Api.Models;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Data
{
    public class NetworkDbContext: DbContext, INetworkDbContext
    {
        public DbSet<Profile> Profiles { get; private set; }
        public DbSet<Position> Positions { get; private set; }
        public DbSet<Company> Companies { get; private set; }
        public DbSet<Organization> Organizations { get; private set; }
        public DbSet<Location> Locations { get; private set; }
        public DbSet<Note> Notes { get; private set; }
        public DbSet<ProfileNote> ProfileNotes { get; private set; }
        public NetworkDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetworkDbContext).Assembly);
        }
        
    }
}
