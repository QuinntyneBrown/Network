using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class ProfileNoteExtensions
    {
        public static ProfileNoteDto ToDto(this ProfileNote profileNote)
        {
            return new()
            {
                ProfileNoteId = profileNote.ProfileNoteId
            };
        }

    }
}
