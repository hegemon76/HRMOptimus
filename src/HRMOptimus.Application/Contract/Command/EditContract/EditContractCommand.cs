using MediatR;

namespace HRMOptimus.Application.Contract.Command.EditContract
{
    public class EditContractCommand : IRequest
    {
        public EditContractVm EditContractVm { get; set; }
    }
}