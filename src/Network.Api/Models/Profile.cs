using System;
using System.Collections.Generic;

namespace Network.Api.Models
{
    public class Profile
    {
        public Guid ProfileId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public Guid? AvatarDigitalAssetId { get; private set; }
        public string Email { get; private set; }
        public string GithubProfile { get; private set; }
        public string LinkedInProfile { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<ProfileNote> ProfileNotes { get; set; } = new();
        public List<Position> Experience { get; set; } = new();

        private Profile()
        {

        }

        public Profile(string firstname, string lastname, string email, string githubProfile)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            GithubProfile = githubProfile;
        }

        public Profile SetAvatarDigitalAssetId(Guid? id)
        {
            AvatarDigitalAssetId = id;
            return this;
        }
    }
}
