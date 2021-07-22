using System;

namespace Network.Api.Models
{
    public class ProfileNote
    {
        public Guid ProfileNoteId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid NoteId { get; set; }
    }
}
