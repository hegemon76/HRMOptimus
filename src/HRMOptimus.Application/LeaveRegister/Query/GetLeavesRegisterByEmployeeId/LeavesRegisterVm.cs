using HRMOptimus.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId
{
    public class LeavesRegisterVm
    {
        public int LeaveDaysByContract { get; set; }
        public int LeaveDaysLeft { get; set; }
        public List<LeaveRecord> LeaveRecords {get;set;}
    }

    public class LeaveRecord
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public IsApproved IsApproved { get; set; }
    }
}