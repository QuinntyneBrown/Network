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
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<Technology> Technologies { get; private set; }
        public DbSet<OrganizationTechnology> OrganizationTechnologies { get; private set; }
        public DbSet<ProfileTechnology> ProfileTechnologies { get; private set; }
        public DbSet<Team> Teams { get; private set; }
        public DbSet<TeamTechnology> TeamTechnologies { get; private set; }
        public DbSet<OrganizationTeam> OrganizationTeams { get; private set; }
        public DbSet<CompanyTeam> CompanyTeams { get; private set; }
        public DbSet<Office> Offices { get; private set; }
        public NetworkDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetworkDbContext).Assembly);
        }
        
    }
}
