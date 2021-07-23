using System;

namespace Network.Api.Features
{
    public class ProfileDto
    {
        public Guid ProfileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
