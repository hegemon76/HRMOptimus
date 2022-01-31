using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Command.RemoveEmployeeFromProject
{
    public class RemoveEmployeeFromProjectCommandHandler : IRequestHandler<RemoveEmployeeFromProjectCommand, Unit>
    {
        private readonly IHRMOptimusDbContext _context;

        public RemoveEmployeeFromProjectCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveEmployeeFromProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.EmployeeId);

            var project = await _context.Projects.Include(x => x.ProjectMembers)
                .FirstOrDefaultAsync(p => p.Id == request.ProjectId);

            project.ProjectMembers.Remove(employee);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}