using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public string Phone { get; private set; }
        public List<Technology> Technologies { get; private set; } = new();
        public List<Skill> Skills { get; private set; } = new();
        public List<ProfileTechnology> ProfileTechnologies { get; private set; } = new();

        [NotMapped]
        public Position CurrentPosition => Experience
            .Where(x => x.DatesEmployed?.EndDate == null)
            .FirstOrDefault();
        public List<ProfileNote> ProfileNotes { get; set; } = new();
        public List<Position> Experience { get; set; } = new();
        public DateTime Created { get; private set; } = DateTime.UtcNow;

        private Profile()
        {

        }

        public Profile(string firstname, string lastname, string email, string githubProfile, string linkedInProfile)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            LinkedInProfile = linkedInProfile;
            GithubProfile = githubProfile;
        }

        public Profile Update(string firstname, string lastname, string email, string githubProfile, string linkedInProfile, Guid? avatarDigitalAssetId)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            LinkedInProfile = linkedInProfile;
            GithubProfile = githubProfile;
            AvatarDigitalAssetId = avatarDigitalAssetId;
            return this;
        }

        public Profile SetAvatarDigitalAssetId(Guid? id)
        {
            AvatarDigitalAssetId = id;
            return this;
        }

        public Profile SetPhone(string phone)
        {
            Phone = phone;
            return this;
        }
    }
}
