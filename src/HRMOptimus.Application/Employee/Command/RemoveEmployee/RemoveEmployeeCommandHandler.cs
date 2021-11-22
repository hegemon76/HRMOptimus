using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Command.RemoveEmployee
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {
        private readonly IHRMOptimusDbContext _context;

        public RemoveEmployeeCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.EmployeeId);

            if (employee == null)
                throw new NotFoundException("There is no employee with Id: " + request.EmployeeId);

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}