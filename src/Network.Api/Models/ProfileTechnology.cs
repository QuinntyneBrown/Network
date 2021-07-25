using System;

namespace Network.Api.Models
{
    public class ProfileTechnology
    {
        public Guid ProfileTechnologyId { get; set; }
        public Profile Profile { get; set; }
        public Technology Technology { get; set; }
        public Guid TechnologyId { get; set; }
        public Guid ProfileId { get; set; }
        public int YearsExperience { get; set; }
    }
}
