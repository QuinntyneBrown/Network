using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class CompanyTeamExtensions
    {
        public static CompanyTeamDto ToDto(this CompanyTeam companyTeam)
        {
            return new ()
            {
                CompanyTeamId = companyTeam.CompanyTeamId
            };
        }
        
    }
}
