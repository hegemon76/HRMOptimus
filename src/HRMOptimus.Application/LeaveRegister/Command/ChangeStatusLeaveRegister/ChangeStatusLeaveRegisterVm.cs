using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister
{
    public class ChangeStatusLeaveRegisterVm
    {
        public int RecordId { get; set; }
        public int EmployeeId { get; set; }
        public IsApproved Status { get; set; }
    }
}
