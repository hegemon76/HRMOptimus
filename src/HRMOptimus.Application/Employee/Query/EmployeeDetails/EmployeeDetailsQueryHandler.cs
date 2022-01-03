using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Query.EmployeeDetails
{
    public class EmployeesQueryHandler : IRequestHandler<EmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IHRMOptimusDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Domain.Entities.Employee _employee;

        public EmployeesQueryHandler(IHRMOptimusDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<EmployeeDetailsVm> Handle(EmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            List<string> roles = new List<string>();
            if (request.EmployeeId == null)
            {
                var fullName = request.Name.ToLower();

                _employee = await _context.Employees
                    .Where(x => x.Enabled)
                    .Include(x => x.Address)
                    .Include(x => x.Contract)
                    .Include(x => x.ApplicationUser)
                    .FirstOrDefaultAsync(x => x.FullName.ToLower().Contains(fullName));

                roles = _userManager.GetRolesAsync(_employee.ApplicationUser).Result.ToList();
            }
            else
            {
                _employee = await _context.Employees
                   .Where(x => x.Enabled)
                   .Include(x => x.Address)
                   .Include(x => x.Contract)
                   .Include(x => x.ApplicationUser)
                   .FirstOrDefaultAsync(x => x.Id == request.EmployeeId);

                roles = _userManager.GetRolesAsync(_employee.ApplicationUser).Result.ToList();
            }

            if (_employee == null)
                throw new NotFoundException("There is no Employee with Id: " + request.EmployeeId + " or FullName: " + request.Name);

            return new EmployeeDetailsVm(_employee.FirstName, _employee.LastName, _employee.FullName, _employee.Gender, _employee.BirthDate,
        _employee.LeaveDaysLeft, _employee.WorkingTime, _employee.Contract, _employee.Address, _employee.ApplicationUser.Email,
        _employee.ApplicationUser.PhoneNumber,roles);
        }
    }
}