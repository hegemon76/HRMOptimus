using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Query.AdminEmployees
{
    public class GetAllAdminEmployeesQuery : IRequest<List<AdminEmployeesVm>>
    { }

    public class AdminEmployeesQueryHandler : IRequestHandler<GetAllAdminEmployeesQuery, List<AdminEmployeesVm>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _context;

        public AdminEmployeesQueryHandler(UserManager<ApplicationUser> userManager, IHRMOptimusDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<AdminEmployeesVm>> Handle(GetAllAdminEmployeesQuery request, CancellationToken cancellationToken)
        {
            var admin = UserRoles.Administrator.ToString();
            var users = _userManager.GetUsersInRoleAsync(UserRoles.Administrator.ToString())
                .Result.AsQueryable().ToList();

            var employees = new List<AdminEmployeesVm>();

            foreach (var user in users)
            {
                var employee = await _context.Employees.Include(x => x.Contract).Include(x => x.Contract)
                    .Where(x => x.Id == user.EmployeeId)
                    .Select(x => new AdminEmployeesVm(x.Id,
                     x.FirstName, x.LastName, x.FullName,
                     x.Gender, x.BirthDate, user.Email,
                     user.PhoneNumber, x.Contract.ContractName)).SingleOrDefaultAsync();

                employees.Add(employee);
            }

            return employees;
        }
    }
}