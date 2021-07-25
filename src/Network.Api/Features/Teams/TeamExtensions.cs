using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class TeamExtensions
    {
        public static TeamDto ToDto(this Team team)
        {
            return new()
            {
                TeamId = team.TeamId
            };
        }

    }
}
