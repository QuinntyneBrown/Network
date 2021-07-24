using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class CompanyExtensions
    {
        public static CompanyDto ToDto(this Company company)
        {
            return new()
            {
                CompanyId = company.CompanyId
            };
        }

    }
}
