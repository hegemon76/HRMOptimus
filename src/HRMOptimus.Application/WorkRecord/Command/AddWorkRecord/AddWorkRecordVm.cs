using System;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    public class AddWorkRecordVm
    {
        public string Name { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public bool IsRemoteWork { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}