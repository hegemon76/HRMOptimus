using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Project.Query.ProjectDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Query.Projects
{
    public class ProjectsQueryHandler : IRequestHandler<ProjectsQuery, List<ProjectVm>>
    {
        private readonly IHRMOptimusDbContext _context;

        public ProjectsQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectVm>> Handle(ProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _context.Projects
                .Where(x => x.Enabled)
                .Select(x => new ProjectVm(x.Id, x.Name, x.Description, x.HoursBudget, x.DateFrom, x.DateTo, x.ColorLabel))
                .ToListAsync();

            return projects;
        }
    }
}