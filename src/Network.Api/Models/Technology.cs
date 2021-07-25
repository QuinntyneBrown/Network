using System;
using System.Collections.Generic;

namespace Network.Api.Models
{
    public class Technology
    {
        public Guid TechnologyId { get; private set; }
        public string Name { get; private set; }
        public string LedBy { get; private set; }
        public string Description { get; private set; }
        public Guid LogoDigitalAssetId { get; private set; }
        public List<Profile> Profiles { get; private set; } = new();

        public Technology(string name, string ledBy, Guid logoDigitalAssetId)
        {
            Name = name;
            LedBy = ledBy;
            LogoDigitalAssetId = logoDigitalAssetId;
        }

        private Technology()
        {

        }
    }
}
