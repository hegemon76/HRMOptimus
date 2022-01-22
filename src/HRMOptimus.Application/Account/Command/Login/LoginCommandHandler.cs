using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Services;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginVm>
    {
        private readonly ICreateTokenService _tokenService;

        private readonly IHRMOptimusDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginCommandHandler(ICreateTokenService tokenService, IHRMOptimusDbContext context, UserManager<ApplicationUser> userManager)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
        }

        public async Task<LoginVm> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                var employee = _context.Employees.FirstOrDefault(x => x.Id == user.EmployeeId);

                return new LoginVm()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.Gender,
                    Token = _tokenService.CreateToken(user.Id)
                };
            }
            return null;
        }
    }
}