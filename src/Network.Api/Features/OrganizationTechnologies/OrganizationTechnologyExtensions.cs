using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class OrganizationTechnologyExtensions
    {
        public static OrganizationTechnologyDto ToDto(this OrganizationTechnology organizationTechnology)
        {
            return new ()
            {
                OrganizationTechnologyId = organizationTechnology.OrganizationTechnologyId
            };
        }
        
    }
}
