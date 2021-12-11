using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(IHRMOptimusDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            //RuleFor(x => x.Password).Custom((context, value) =>
            //  {
            //      var user = userManager.FindByEmailAsync(request.Email).GetAwaiter();
            //      var result = userManager.CheckPasswordAsync(user, request.Password);
            //  });
        }
    }
}