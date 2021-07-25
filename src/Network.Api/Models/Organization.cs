using System;
using System.Collections.Generic;

namespace Network.Api.Models
{
    public class Organization
    {
        public Guid OrganizationId { get; private set; }       
        public string Name { get; private set; }
        public List<Company> Companies { get; private set; } = new();
        public Guid? LogoDigitalAssetId { get; private set; }

        public Organization(
            string name,
            Guid? logoDigitalAssetId = null)
        {
            Name = name;
            LogoDigitalAssetId = logoDigitalAssetId;
        }

        private Organization()
        {

        }
    }
}
