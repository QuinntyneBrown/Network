using System;

namespace Network.Api.Features
{
    public class ProfileDto
    {
        public Guid? ProfileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Guid? AvatarDigitalAssetId { get; set; }
        public string Email { get; set; }
        public string GithubProfile { get; set; }
        public string LinkedInProfile { get; set; }

    }
}
