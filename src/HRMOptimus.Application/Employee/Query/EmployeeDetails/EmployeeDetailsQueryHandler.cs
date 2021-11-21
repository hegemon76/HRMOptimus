using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
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
                var fullName = request.Name.ToLower();

                _employee = await _context.Employees
                    .Where(x => x.Enabled)
                    .Include(x => x.Address)
                    .Include(x => x.Contract)
                    .Include(x => x.ApplicationUser)
                    .FirstOrDefaultAsync(x => x.FullName.ToLower().Contains(fullName));
            }
            else
                _employee = await _context.Employees
                   .Where(x => x.Enabled)
                   .Include(x => x.Address)
                   .Include(x => x.Contract)
                   .Include(x => x.ApplicationUser)
                   .FirstOrDefaultAsync(x => x.Id == request.EmployeeId);

            if (_employee == null)
                throw new NotFoundException("There is no Employee with Id: " + request.EmployeeId + " or FullName: " + request.Name);

            return new EmployeeDetailsVm(_employee.FirstName, _employee.LastName, _employee.FullName, _employee.Gender, _employee.BirthDate,
        _employee.LeaveDaysLeft, _employee.WorkingTime, _employee.Contract, _employee.Address, _employee.ApplicationUser.Email, _employee.ApplicationUser.PhoneNumber);
        }
    }
}