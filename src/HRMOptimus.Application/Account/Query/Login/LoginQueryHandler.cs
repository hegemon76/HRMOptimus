using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using HRMOptimus.Domain.Entities;

namespace HRMOptimus.Application.User.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginVm>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginQueryHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LoginVm> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (result.Succeeded)
            {
                return new LoginVm("test", "test2", "21");
            }

            return new LoginVm("test", "test2", "21");
        }
    }
}
