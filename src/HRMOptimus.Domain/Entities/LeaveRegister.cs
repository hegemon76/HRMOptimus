using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Enums;
using System;

namespace HRMOptimus.Domain.Entities
{
    public class LeaveRegister : EntityBase
    {
        public int Duration { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public IsApproved IsApproved { get; set; }
        public LeaveRegisterType LeaveRegisterType { get; set; }
    }
}