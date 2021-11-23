using MediatR;

namespace HRMOptimus.Application.Employee.Command.RemoveEmployee
{
    public class RemoveEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
    }
}