using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Project.Query.ProjectDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Query.EmployeeDetails
{
    public class EmployeesQueryHandler : IRequestHandler<EmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IHRMOptimusDbContext _context;
        private Domain.Entities.Employee _employee;

        public EmployeesQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDetailsVm> Handle(EmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request.EmployeeId == null)
            {
                _employee = await _context.Employees
                    .Include(x => x.Address)
                    .Include(x => x.Contract)
                    .FirstOrDefaultAsync(x => x.FullName.ToLower().Contains(request.Name.ToLower()));
            }
            else
                _employee = await _context.Employees
                   .Include(x => x.Address)
                   .Include(x => x.Contract)
                   .FirstOrDefaultAsync(x => x.Id == request.EmployeeId);

            return new EmployeeDetailsVm(_employee);
        }
    }
}