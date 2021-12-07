using HRMOptimus.Domain.Enums;
using System;

namespace HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister
{
    public class AddLeaveRegisterVm
    {
        public DateTime LeaveStart { get; set; }
        public DateTime LeaveEnd { get; set; }
        public int EmployeeId { get; set; }
        public LeaveRegisterType LeaveRegisterType  { get; set; }
    }
}
