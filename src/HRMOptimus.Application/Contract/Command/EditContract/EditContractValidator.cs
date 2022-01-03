using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Contract.Command.EditContract
{
    public class EditContractValidator : AbstractValidator<EditContractVm>
    {
        public EditContractValidator()
        {
            RuleFor(x => x.ContractId).NotEmpty();
        }
    }
}
