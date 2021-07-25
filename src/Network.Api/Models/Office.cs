using System;

namespace Network.Api.Models
{
    public class Office
    {
        public Guid OfficeId { get; private set; }
        public Guid OrganizationId { get; private set; }
        public Address Address { get; private set; }
        public Office(Guid organizationId, Address address)
        {
            OrganizationId = organizationId;
            Address = address;
        }

        private Office()
        {

        }
    }
}
