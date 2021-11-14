using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId
{
    public class GetLeavesRegisterByEmployeeIdQuery :IRequest<List<LeavesRegisterListVm>>
    {
        public int EmployeeId { get; set; }
    }
}
