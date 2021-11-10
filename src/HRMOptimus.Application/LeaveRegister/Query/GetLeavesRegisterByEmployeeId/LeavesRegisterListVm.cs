using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId
{
    public class LeavesRegisterListVm
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
    }
}
