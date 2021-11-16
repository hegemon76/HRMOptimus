using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Query.Employees
{
    public class EmployeesQueryHandler : IRequestHandler<EmployeesQuery, List<EmployeeVm>>
    {
        private readonly IHRMOptimusDbContext _context;

        public EmployeesQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeVm>> Handle(EmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees
                .Where(x => x.Enabled)
                .Include(x => x.ApplicationUser)
                .Select(x => new EmployeeVm(x.Id, x.FirstName, x.LastName, x.FullName, x.Gender, x.BirthDate, x.ApplicationUser.Email, x.ApplicationUser.PhoneNumber))
                .ToListAsync();

            return employees;
        }
    }
}