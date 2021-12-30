using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationVmValidator : AbstractValidator<RegistrationVm>
    {
        public RegistrationVmValidator(IHRMOptimusDbContext dbContext)
        {
            #region ApplicationUser

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.ApplicationUsers.Any(e => e.Email == value);
                    if (emailInUse)
                        context.AddFailure("Email", "That email is taken");
                });

            RuleFor(x => x.Password).MinimumLength(8);
            RuleFor(x => x.Password)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^#&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{PropertyName}' must contain one or more special characters.")
                .MinimumLength(8);
            
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.Roles).NotEmpty();
            #endregion
        }
    }
}