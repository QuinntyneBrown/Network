using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class ProfileTechnologyExtensions
    {
        public static ProfileTechnologyDto ToDto(this ProfileTechnology profileTechnology)
        {
            return new ()
            {
                ProfileTechnologyId = profileTechnology.ProfileTechnologyId
            };
        }
        
    }
}
