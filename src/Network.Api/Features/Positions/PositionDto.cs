using Network.Api.Models;
using System;

namespace Network.Api.Features
{
    public class PositionDto
    {
        public Guid? PositionId { get; set; }
        public string Title { get; set; }
        public PositionType PositionType { get; set; }
        public Guid? CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public DatesEmployedDto DatesEmployed { get; set; }
        public bool IsCurrent { get; set; }
        public Stack Stack { get; set; }
        public Senority Senority { get; set; }
        public string Description { get; set; }
    }
}
