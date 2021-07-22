using System;

namespace Network.Api.Models
{
    public class Position
    {
        public Guid PositionId { get; set; }
        public string Title { get; set; }
        public PositionType PositionType { get; set; } = PositionType.FullTime;
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public DatesEmployed DatesEmployed { get; set; }
        public bool IsCurrent { get; set; }
        public Stack Stack { get; set; }
        public Senority Senority { get; set; }
    }
}
