using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Query.ProjectDetails
{
    public class ProjectDetailsQueryHandler : IRequestHandler<ProjectDetailsQuery, ProjectDetailsVm>
    {
        private readonly IHRMOptimusDbContext _context;

        public ProjectDetailsQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectDetailsVm> Handle(ProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects
                .Include(x => x.ProjectMembers)
                .FirstOrDefaultAsync(x => x.Id == request.ProjectId);

            return new ProjectDetailsVm(project.Name, project.Description, project.HoursBudget, project.HoursWorked, project.DateFrom,
                project.DateTo, project.Deadline, project.ProjectMembers);
        }
    }
}