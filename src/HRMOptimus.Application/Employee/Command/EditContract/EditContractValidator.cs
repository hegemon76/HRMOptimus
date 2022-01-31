using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.Employee.Command.EditContract
{
    public class EditContractValidator : AbstractValidator<EditContractVm>
    {
        public EditContractValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.ContractId).NotEmpty().Custom((value, context) =>
            {
                var contract = dbContext.Contracts.Any(e => e.Id == value && e.Enabled);
                if (!contract)
                    context.AddFailure("Id", "The Contract with Id: " + value + " doesn't exist");
            });
        }
    }
}