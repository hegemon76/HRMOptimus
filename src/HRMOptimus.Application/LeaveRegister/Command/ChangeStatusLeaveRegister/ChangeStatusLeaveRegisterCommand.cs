using MediatR;

namespace HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister
{
    public class ChangeStatusLeaveRegisterCommand : IRequest<int>
    {
        public ChangeStatusLeaveRegisterVm ChangeStatusLeaveRegisterVm { get; set; }
    }
}
