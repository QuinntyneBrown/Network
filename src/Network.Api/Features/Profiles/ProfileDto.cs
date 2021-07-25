using System;
using System.Collections.Generic;

namespace Network.Api.Features
{
    public class ProfileDto
    {
        public Guid? ProfileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Guid? AvatarDigitalAssetId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GithubProfile { get; set; }
        public string LinkedInProfile { get; set; }
        public DateTime Created { get; set; }
        public List<PositionDto> Experience { get; set; } = new();
        public PositionDto CurrentPosition { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
        public List<ProfileTechnologyDto> ProfileTechnologyies { get; set; }

    }
}
