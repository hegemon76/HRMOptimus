using MediatR;

namespace HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister
{

    public class AddLeaveRegisterCommand : IRequest<int>
    {
        public AddLeaveRegisterVm AddLeaveRegisterVm { get; set; }
    }
}
