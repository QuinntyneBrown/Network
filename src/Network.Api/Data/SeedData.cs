using Network.Api.Extensions;
using Network.Api.Models;
using System.Linq;

namespace Network.Api.Data
{
    public static class SeedData
    {
        public static void Seed(NetworkDbContext context)
        {
            ProfileConfiguration.Seed(context);
        }
    }

    public static class ProfileConfiguration
    {
        public static void Seed(NetworkDbContext context)
        {
            var profile = context.Profiles
                .Search("Firstname", "Quinntyne")
                .Search("Lastname", "Brown")
                .SingleOrDefault();

            if(profile == null)
            {
                profile = new Profile("Quinntyne", "Brown", "quinntynebrown@gmail.com");
                context.Profiles.Add(profile);
                context.SaveChanges();
            }
        }
    }
}
