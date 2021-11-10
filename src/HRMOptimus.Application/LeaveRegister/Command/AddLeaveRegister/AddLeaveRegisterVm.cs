using System;

namespace HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister
{
    public class AddLeaveRegisterVm
    {
        public string Name { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}
