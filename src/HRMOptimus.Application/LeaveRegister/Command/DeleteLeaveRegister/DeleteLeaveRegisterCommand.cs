using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Command.DeleteLeaveRegister
{
    public class DeleteLeaveRegisterCommand : IRequest<int>
    {
        public DeleteLeaveRegisterVm DeleteLeaveRegisterVm { get; set; }
    }
}
