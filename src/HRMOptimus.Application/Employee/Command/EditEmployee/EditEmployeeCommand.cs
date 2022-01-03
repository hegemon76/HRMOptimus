using HRMOptimus.Application.Account.Command.Registration;
using MediatR;

namespace HRMOptimus.Application.Employee.Command.EditEmployee
{
    public class EditEmployeeCommand : IRequest
    {
        public EditEmployeeVm Employee { get; set; }
    }
}