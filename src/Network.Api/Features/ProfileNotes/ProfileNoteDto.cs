using System;

namespace Network.Api.Features
{
    public class ProfileNoteDto
    {
        public Guid? ProfileNoteId { get; set; }
        public Guid ProfileId { get; set; }
        public NoteDto Note { get; set; }
    }
}
