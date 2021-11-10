using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister
{

    public class AddLeaveRegisterCommand : IRequest<int>
    {
        public AddLeaveRegisterVm AddLeaveRegisterVm { get; set; }
    }
}
