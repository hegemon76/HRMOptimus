using FluentValidation;

namespace HRMOptimus.Application.Account.Command.Password.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordVm>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.NewPassword).MinimumLength(8);
            RuleFor(x => x.NewPassword)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^#&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{PropertyName}' must contain one or more special characters.")
                .MinimumLength(8);
        }
    }
}