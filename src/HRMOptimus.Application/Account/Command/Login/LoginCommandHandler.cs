using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

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
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
                var user = _userManager.FindByIdAsync(userId);
                var employee = _context.Employees.FirstOrDefault(x => x.Id == user.Result.EmployeeId);

                return new LoginVm() {
                    EmployeeId = employee.Id,
                    FirstName = employee.FirstName,
                    Gender = employee.Gender,
                    LastName = employee.LastName,
                    Id = userId,
                };
            }
            return null;
        }
    }
}
