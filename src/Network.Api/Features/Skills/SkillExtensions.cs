using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class SkillExtensions
    {
        public static SkillDto ToDto(this Skill skill)
        {
            return new ()
            {
                SkillId = skill.SkillId
            };
        }
        
    }
}
