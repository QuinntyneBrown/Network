using System;
using System.Collections.Generic;

namespace Network.Api.Models
{
    public class Skill
    {
        public Guid SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Profile> Profiles { get; private set; } = new();
    }
}
