using FluentValidation;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRMOptimus.Application.Account.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(UserManager<ApplicationUser> userManager)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Custom((email, context) =>
            {
                var user = userManager.FindByEmailAsync(email).Result;

                if (user is null)
                {
                    context.AddFailure("Wrong password or email");
                }
            });
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}