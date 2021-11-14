using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Project.Query.ProjectDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Query.Projects
{
    public class ProjectsQueryHandler : IRequestHandler<ProjectsQuery, ProjectsVm>
    {
        private readonly IHRMOptimusDbContext _context;

        public ProjectsQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectsVm> Handle(ProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _context.Projects
                .Include(x => x.ProjectMembers)
                .Select(x => new ProjectDetailsVm(x.Name, x.Description, x.HoursBudget, x.HoursWorked, x.DateFrom,
                    x.DateTo, x.Deadline, x.ProjectMembers))
                .ToListAsync();

            return new ProjectsVm(projects);
        }
    }
}