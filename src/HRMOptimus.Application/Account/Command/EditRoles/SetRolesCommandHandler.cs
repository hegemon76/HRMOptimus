using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.SetRoles
{
    public class SetRolesCommandHandler : IRequestHandler<SetRolesCommand, Unit>
    {
        private readonly IHRMOptimusDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SetRolesCommandHandler(IHRMOptimusDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SetRolesCommand request, CancellationToken cancellationToken)
        {
            var employee = _userManager.FindByNameAsync(request.AddToRoleVm.Email);
        
            if (employee.Result != null)
            {
                var userRoles = _userManager.GetRolesAsync(employee.Result).Result;
                await _userManager.RemoveFromRolesAsync(employee.Result, userRoles);

                List<string> requestRoles = new List<string>();
                foreach (var role in request.AddToRoleVm.UserRoles)
                {
                    requestRoles.Add(role.ToString());
                }
                await _userManager.AddToRolesAsync(employee.Result, requestRoles);
            }

            return Unit.Value;
        }
    }
}