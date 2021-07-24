using Network.Api.Models;

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
                GithubProfile = profile.GithubProfile,
                LinkedInProfile = profile.LinkedInProfile,
                AvatarDigitalAssetId = profile.AvatarDigitalAssetId,
                Created = profile.Created

            };
        }
    }
}
