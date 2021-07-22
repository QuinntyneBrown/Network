using System;
using System.Collections.Generic;

namespace Network.Api.Models
{
    public class Organization
    {
        public Guid OrganizationId { get; set; }
        public List<Company> Companies { get; set; } = new();
        public string Name { get; set; }
    }
}
