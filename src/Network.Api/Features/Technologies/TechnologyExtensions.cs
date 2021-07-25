using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class TechnologyExtensions
    {
        public static TechnologyDto ToDto(this Technology technology)
        {
            return new()
            {
                TechnologyId = technology.TechnologyId
            };
        }

    }
}
