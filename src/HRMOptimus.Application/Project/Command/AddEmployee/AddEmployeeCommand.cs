using MediatR;

namespace HRMOptimus.Application.Project.Command.AddEmployee
{
    public class AddEmployeeCommand : IRequest<int>
    {
        public AddEmployeeVm AddEmployeeVm { get; set; }
    }
}