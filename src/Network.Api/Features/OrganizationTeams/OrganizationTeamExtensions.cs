using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class OrganizationTeamExtensions
    {
        public static OrganizationTeamDto ToDto(this OrganizationTeam organizationTeam)
        {
            return new ()
            {
                OrganizationTeamId = organizationTeam.OrganizationTeamId
            };
        }
        
    }
}
