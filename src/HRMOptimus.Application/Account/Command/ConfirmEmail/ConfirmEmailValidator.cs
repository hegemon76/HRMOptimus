using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace HRMOptimus.Application.Account.Command.ConfirmEmail
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailValidator(UserManager<ApplicationUser> userManager, IHRMOptimusDbContext dbContext, IUserContextService userService)
        {
            RuleFor(x => x.ConfirmationToken)
            .Custom((value, context) =>
            {
                var employeeId = userService.GetEmployeeId;

                var user = dbContext.ApplicationUsers
                    .FirstOrDefault(x => x.EmployeeId == employeeId);

                if (user == null)
                    context.AddFailure("User not found");

                var isConfirmed = userManager.ConfirmEmailAsync(user, value).Result;
                if (!isConfirmed.Succeeded)
                    context.AddFailure("Confirmation token is invalid");
            });
        }
    }
}