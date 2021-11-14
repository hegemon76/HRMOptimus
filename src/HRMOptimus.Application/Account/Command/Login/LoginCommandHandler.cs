using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRMOptimus.Application.Account.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginVm>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHRMOptimusDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor,
            IHRMOptimusDbContext context, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
        }

        public async Task<LoginVm> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (result.Succeeded)
            {
                var user2 = await _userManager.FindByEmailAsync(request.Email);
                Employee employee = _context.Employees
                    .FirstOrDefault(x => x.Id == user2.EmployeeId);

                return new LoginVm()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.Gender,
                    Id = user2.Id.ToString(),
                    EmployeeId = employee.Id
                };
            }
            return null;
        }
    }
}