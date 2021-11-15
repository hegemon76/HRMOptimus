using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Query.Employees
{
    public class EmployeesQueryHandler : IRequestHandler<EmployeesQuery, EmployeesVm>
    {
        private readonly IHRMOptimusDbContext _context;

        public EmployeesQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeesVm> Handle(EmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees
                .ToListAsync();

            return new EmployeesVm(employees);
        }
    }
}