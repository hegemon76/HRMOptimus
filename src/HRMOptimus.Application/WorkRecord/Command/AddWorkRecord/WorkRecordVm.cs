using System;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    class WorkRecordVm
    {
        public string Name { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}
