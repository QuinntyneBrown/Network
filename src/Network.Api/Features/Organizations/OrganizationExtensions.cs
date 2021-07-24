using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class OrganizationExtensions
    {
        public static OrganizationDto ToDto(this Organization organization)
        {
            return new()
            {
                OrganizationId = organization.OrganizationId
            };
        }

    }
}
