using System;
using System.Collections.Generic;

namespace Network.Api.Models
{
    public class Profile
    {
        public Guid ProfileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProfileNote> ProfileNotes { get; set; } = new();
        public List<Position> Experience { get; set; } = new();
    }
}
