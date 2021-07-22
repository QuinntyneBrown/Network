using System;

namespace Network.Api.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public Guid OrganizationId { get; set; }
        public Location Location { get; set; }
    }
}
