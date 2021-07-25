using System;
using System.Linq;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class TechnologyExtensions
    {
        public static TechnologyDto ToDto(this Technology technology)
        {
            return new()
            {
                TechnologyId = technology.TechnologyId,
                Name = technology.Name,
                LedBy = technology.LedBy,
                LogoDigitalAssetId = technology.LogoDigitalAssetId,
                Description = technology.Description,
                Profiles = technology.Profiles.Select(x => x.ToDto()).ToList()
            };
        }
    }
}
