using Network.Api.Models;
using System.Linq;

namespace Network.Api.Features
{
    public static class ProfileExtensions
    {
        public static ProfileDto ToDto(this Profile profile)
        {
            return new()
            {
                ProfileId = profile.ProfileId,
                Firstname = profile.Firstname,
                Lastname = profile.Lastname,
                Email = profile.Email,
                Phone = profile.Phone,
                GithubProfile = profile.GithubProfile,
                LinkedInProfile = profile.LinkedInProfile,
                AvatarDigitalAssetId = profile.AvatarDigitalAssetId,
                Created = profile.Created,
                Experience = profile.Experience?.Select(x => x?.ToDto()).ToList()
            };
        }
    }
}
