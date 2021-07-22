using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class NoteExtensions
    {
        public static NoteDto ToDto(this Note note)
        {
            return new ()
            {
                NoteId = note.NoteId
            };
        }
        
    }
}
