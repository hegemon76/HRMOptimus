using HRMOptimus.Domain.Common;
using System;

namespace HRMOptimus.Domain.Entities
{
    public class WorkRecord : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime WorkStartOn { get; set; }
        public DateTime WorkStopOn { get; set; }
        public DateTime WorkedHours { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string User { get; set; }

        //public void ComputeWorkedHours()
        //{
        //    WorkedHours = DateTime.TryParse(WorkStartOn.Minute - WorkStopOn.Minute, out DateTime date);
        //}
    }
}
