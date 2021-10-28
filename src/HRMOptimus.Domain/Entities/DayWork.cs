using HRMOptimus.Domain.Common;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Domain.Entities
{
    public class DayWork: EntityBase
    {
        public int Id { get; set; }
        public DateTime Day { get; set; } = DateTime.Now;
        public bool DayOff { get; set; } = false;
        public ICollection<WorkRecord> WorkRekords { get; set; }
        public MonthWork WorkingMonth { get; set; }
        public Employee Employee { get; set; }
    }
}
