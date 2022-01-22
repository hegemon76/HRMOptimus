using MediatR;

namespace HRMOptimus.Application.LeaveRegister.Command.DeleteLeaveRegister
{
    public class DeleteLeaveRegisterCommand : IRequest
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
    }
}