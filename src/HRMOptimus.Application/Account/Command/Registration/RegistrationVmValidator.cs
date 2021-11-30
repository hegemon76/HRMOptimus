using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationVmValidator : AbstractValidator<RegistrationVm>
    {
        public RegistrationVmValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(8);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.ApplicationUsers.Any(e => e.Email == value);
                    if (emailInUse)
                        context.AddFailure("Email", "That email is taken");
                });
        }
    }
}