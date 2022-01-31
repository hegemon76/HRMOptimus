using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.Account.Command.ChangeEmail
{
    public class ChangeEmailValidator : AbstractValidator<ChangeEmailVm>
    {
        public ChangeEmailValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.ApplicationUserId).NotEmpty();
           
            RuleFor(x => x.NewEmail)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.ApplicationUsers.Any(e => e.Email == value);
                    if (emailInUse)
                        context.AddFailure("Email", "That email is taken");
                });
        }
    }
}