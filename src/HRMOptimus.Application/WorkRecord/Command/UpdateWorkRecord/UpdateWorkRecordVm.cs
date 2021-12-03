using System;

namespace HRMOptimus.Application.WorkRecord.Command.UpdateWorkRecord
{
    public class UpdateWorkRecordVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}