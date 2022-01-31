using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRMOptimus.Application.Account.Command.ConfirmEmail
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailValidator(UserManager<ApplicationUser> userManager, IUserContextService userService)
        {
            RuleFor(x => x.ConfirmationToken)
            .Custom((value, context) =>
            {
                var userId = userService.GetUserId;
                var user = userManager.FindByIdAsync(userId).Result;
                if (user == null)
                    context.AddFailure("User not found");

                var isConfirmed = userManager.ConfirmEmailAsync(user, value).Result;
                if (!isConfirmed.Succeeded)
                    context.AddFailure("Confirmation token is invalid");
            });
        }
    }
}