using System;

namespace Network.Api.Features
{
    public class OfficeDto
    {
        public Guid OfficeId { get; set; }
        public Guid OrganizationId { get; set; }
        public AddressDto Address { get; set; }
    }
}
