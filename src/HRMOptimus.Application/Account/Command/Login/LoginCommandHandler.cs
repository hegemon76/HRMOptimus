using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;
using HRMOptimus.Application.Common.Services;

namespace HRMOptimus.Application.Account.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginVm>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IHRMOptimusDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager, TokenService tokenService,
            IHRMOptimusDbContext context, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;

        }

        public async Task<LoginVm> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (result.Succeeded)
            {
                var user2 = await _userManager.FindByEmailAsync(request.Email);
                Domain.Entities.Employee employee = _context.Employees
                    .FirstOrDefault(x => x.Id == user2.EmployeeId);



                return new LoginVm()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.Gender,
                    Token = _tokenService.CreateToken(user2.Id, employee.Id.ToString())
                };
            }
            return null;
        }
    }
}