using System;

namespace Network.Api.Models
{
    public class Position
    {
        public Guid PositionId { get; private set; }
        public string Title { get; private set; }
        public PositionType PositionType { get; private set; } = PositionType.FullTime;
        public Guid? OfficeId { get; private set; }
        public Office Office { get; private set; }
        public Guid? OrganizationId { get; private set; }
        public Organization Organization { get; private set; }
        public DatesEmployed DatesEmployed { get; private set; }
        public bool IsCurrent { get; private set; }
        public Stack Stack { get; private set; }
        public Senority Senority { get; private set; }
        public string Description { get; private set; }

        private Position()
        {

        }

        public Position(string title)
        {
            Title = title;
        }

        public Position(Guid? organizationId, string title)
        {
            OrganizationId = organizationId;
            Title = title;
        }
    }
}
