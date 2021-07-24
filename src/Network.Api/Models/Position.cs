using System;

namespace Network.Api.Models
{
    public class Position
    {
        public Guid PositionId { get; private set; }
        public string Title { get; private set; }
        public PositionType PositionType { get; private set; } = PositionType.FullTime;
        public Guid? CompanyId { get; private set; }
        public Company Company { get; private set; }
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
    }
}
