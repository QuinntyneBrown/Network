using System;
using Network.Api.Models;

namespace Network.Api.Features
{
    public static class PositionExtensions
    {
        public static PositionDto ToDto(this Position position)
        {
            if (position == null)
                return null;

            return new()
            {
                PositionId = position?.PositionId,
                Title = position?.Title,
                IsCurrent = position.IsCurrent,
                DatesEmployed =  new DatesEmployedDto { StartDate = position.DatesEmployed?.StartDate, EndDate = position.DatesEmployed?.EndDate },
                CompanyId = position.CompanyId,
                Company = position.Company.ToDto(),
                Stack = position.Stack,
                Senority = position.Senority,
                Description = position.Description
            };
        }
    }
}
