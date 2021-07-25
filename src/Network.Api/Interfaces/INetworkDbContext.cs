using Network.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Network.Api.Interfaces
{
    public interface INetworkDbContext
    {
        DbSet<Profile> Profiles { get; }
        DbSet<Position> Positions { get; }
        DbSet<Company> Companies { get; }
        DbSet<Organization> Organizations { get; }
        DbSet<Location> Locations { get; }
        DbSet<Note> Notes { get; }
        DbSet<ProfileNote> ProfileNotes { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<Technology> Technologies { get; }
        DbSet<OrganizationTechnology> OrganizationTechnologies { get; }
        DbSet<ProfileTechnology> ProfileTechnologies { get; }
        DbSet<Team> Teams { get; }
        DbSet<TeamTechnology> TeamTechnologies { get; }
        DbSet<OrganizationTeam> OrganizationTeams { get; }
        DbSet<CompanyTeam> CompanyTeams { get; }
        DbSet<Office> Offices { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
