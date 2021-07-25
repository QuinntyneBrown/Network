using System;
using System.Collections.Generic;

namespace Network.Api.Features
{
    public class TechnologyDto
    {
        public Guid TechnologyId { get; set; }
        public string Name { get; set; }
        public string LedBy { get; set; }
        public Guid LogoDigitalAssetId { get; set; }
        public string Description { get; set; }
        public List<ProfileDto> Profiles { get; set; } = new();
    }
}
