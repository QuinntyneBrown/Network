using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class ProfileExtensions
    {
        public static ProfileDto ToDto(this Profile profile)
        {
            return new ()
            {
                ProfileId = profile.ProfileId
            };
        }
        
    }
}
