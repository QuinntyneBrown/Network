using Network.Api.Extensions;
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

            if (profile == null)
            {
                context.Profiles.Add(new(
                    "Quinntyne", "Brown",
                    "quinntynebrown@gmail.com",
                    "https://github.com/QuinntyneBrown",
                    "https://www.linkedin.com/in/quinntynebrown/"));
                context.SaveChanges();
            }
        }
    }
}
