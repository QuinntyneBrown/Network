using Network.Api.Models;
using System.Linq;

namespace Network.Api.Features
{
    public static class OrganizationExtensions
    {
        public static OrganizationDto ToDto(this Organization organization)
        {
            return new()
            {
                OrganizationId = organization.OrganizationId,
                LogoDigitalAssetId = organization.LogoDigitalAssetId,
                Name = organization.Name,
                Companies = organization.Companies.Select(x => x.ToDto()).ToList()
            };
        }

    }
}
