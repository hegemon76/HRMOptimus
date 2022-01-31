using MediatR;

namespace HRMOptimus.Application.Employee.Command.EditContract
{
    public class EditContractCommand : IRequest
    {
        public EditContractVm EditContractVm { get; set; }
    }
}