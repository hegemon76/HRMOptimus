using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Password.ConfirmPassword
{
    public class ConfirmPasswordValidator : AbstractValidator<ConfirmPasswordCommand>
    {
        public ConfirmPasswordValidator()
        {
            
            RuleFor(x => x.Token).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(x => x.Token).Custom((value, context) =>{
                if (value == null)
                    context.AddFailure("test");
            });
        }
    }
}
