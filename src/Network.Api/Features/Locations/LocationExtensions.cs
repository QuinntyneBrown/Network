using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class LocationExtensions
    {
        public static LocationDto ToDto(this Location location)
        {
            return new ()
            {
                LocationId = location.LocationId
            };
        }
        
    }
}
