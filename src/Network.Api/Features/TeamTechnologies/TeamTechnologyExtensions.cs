using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class TeamTechnologyExtensions
    {
        public static TeamTechnologyDto ToDto(this TeamTechnology teamTechnology)
        {
            return new()
            {
                TeamTechnologyId = teamTechnology.TeamTechnologyId
            };
        }

    }
}
