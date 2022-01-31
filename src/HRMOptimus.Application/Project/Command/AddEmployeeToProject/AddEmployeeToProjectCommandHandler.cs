using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Command.AddEmployeeToProject
{
    public class AddEmployeeToProjectCommandHandler : IRequestHandler<AddEmployeeToProjectCommand>
    {
        private readonly IHRMOptimusDbContext _context;

        public AddEmployeeToProjectCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddEmployeeToProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.EmployeeId);

            var project = await _context.Projects.Include(x => x.ProjectMembers)
                .FirstOrDefaultAsync(p => p.Id == request.ProjectId);

            project.ProjectMembers.Add(employee);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}