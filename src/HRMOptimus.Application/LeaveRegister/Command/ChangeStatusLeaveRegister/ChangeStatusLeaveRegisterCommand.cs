using MediatR;

namespace HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister
{
    public class ChangeStatusLeaveRegisterCommand : IRequest<Unit>
    {
        public ChangeStatusLeaveRegisterVm ChangeStatusLeaveRegisterVm { get; set; }
    }
}