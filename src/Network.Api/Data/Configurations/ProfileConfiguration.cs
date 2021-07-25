using Network.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Network.Api.Data.Configurations
{
    public class ProfileConfiguration: IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .HasMany(p => p.Technologies)
                .WithMany(p => p.Profiles)
                .UsingEntity<ProfileTechnology>(
                j => j.HasOne(pt => pt.Technology).WithMany().HasForeignKey(pt => pt.TechnologyId),
                j => j.HasOne(pt => pt.Profile).WithMany().HasForeignKey(pt => pt.ProfileId),
                j =>
                {
                    j.HasKey(t => new { t.TechnologyId, t.ProfileId });
                });
        }        
    }
}
