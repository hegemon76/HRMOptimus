using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Command.EditContract
{
    public class EditContractCommandHandler : IRequestHandler<EditContractCommand, Unit>
    {
        private readonly IHRMOptimusDbContext _context;

        public EditContractCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(EditContractCommand request, CancellationToken cancellationToken)
        {
            var contractToEdit = _context.Contracts.FirstOrDefault(x => x.Id == request.EditContractVm.ContractId);

            contractToEdit.ContractName =
                !string.IsNullOrWhiteSpace(request.EditContractVm.ContractName) ? request.EditContractVm.ContractName : contractToEdit.ContractName;

            contractToEdit.LeaveDays =
               request.EditContractVm.LeaveDays.HasValue ? request.EditContractVm.LeaveDays.Value : contractToEdit.LeaveDays;

            contractToEdit.Payment =
                request.EditContractVm.Payment.HasValue ? request.EditContractVm.Payment.Value : contractToEdit.Payment;

            contractToEdit.Rate =
                request.EditContractVm.Rate.HasValue ? request.EditContractVm.Rate.Value : contractToEdit.Rate;

            contractToEdit.WorkTime =
                request.EditContractVm.WorkTime.HasValue ? request.EditContractVm.WorkTime.Value : contractToEdit.WorkTime;

            contractToEdit.ContractType =
                request.EditContractVm.ContractType != contractToEdit.ContractType ? request.EditContractVm.ContractType : contractToEdit.ContractType;

            _context.Contracts.Update(contractToEdit);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
