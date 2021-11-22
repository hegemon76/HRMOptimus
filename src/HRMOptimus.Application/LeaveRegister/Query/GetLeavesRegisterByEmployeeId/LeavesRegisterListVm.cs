using HRMOptimus.Domain.Enums;
using System;

namespace HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId
{
    public class LeavesRegisterListVm
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public IsApproved IsApproved { get; set; }
    }
}