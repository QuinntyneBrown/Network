using System;
using System.Collections.Generic;

namespace Network.Api.Models
{
    public class Profile
    {
        public Guid ProfileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Position> Experience { get; set; } = new();
    }
}
