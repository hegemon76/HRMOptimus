using MediatR;

namespace HRMOptimus.Application.Project.Command.AddEmployee
{
    public class AddEmployeeCommand : IRequest
    {
        public AddEmployeeVm AddEmployeeVm { get; set; }
    }
}