using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class PositionExtensions
    {
        public static PositionDto ToDto(this Position position)
        {
            return new()
            {
                PositionId = position.PositionId
            };
        }

    }
}
