using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
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

            if (!result)
            {
                throw new BadRequestException("Wrong password or email");
            }

            var employee = _context.Employees.FirstOrDefault(x => x.Id == user.EmployeeId);

            return new LoginVm()
            {
                FullName = employee.FullName,
                Gender = employee.Gender,
                Token = await _tokenService.CreateToken(user.Id)
            };
        }
    }
}