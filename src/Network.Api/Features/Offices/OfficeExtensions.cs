using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class OfficeExtensions
    {
        public static OfficeDto ToDto(this Office office)
        {
            return new()
            {
                OfficeId = office?.OfficeId
            };
        }

    }
}
