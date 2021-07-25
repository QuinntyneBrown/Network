using System;
using System.Collections.Generic;

namespace Network.Api.Features
{
    public class OrganizationDto
    {
        public Guid? OrganizationId { get; set; }
        public string Name { get; set; }
        public List<CompanyDto> Companies { get; set; } = new();
        public Guid? LogoDigitalAssetId { get; set; }
    }
}
