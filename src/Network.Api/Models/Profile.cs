using System;
using System.Collections.Generic;

namespace Network.Api.Models
{
    public class Profile
    {
        public Guid ProfileId { get; set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<ProfileNote> ProfileNotes { get; set; } = new();
        public List<Position> Experience { get; set; } = new();
    }
}
