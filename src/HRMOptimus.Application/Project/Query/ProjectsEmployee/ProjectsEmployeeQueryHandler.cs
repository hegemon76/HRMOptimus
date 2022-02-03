using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Project.Query.Projects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Query.ProjectsEmployee
{
    public class ProjectsEmployeeQueryQueryQueryHandler : IRequestHandler<ProjectsEmployeeQuery, List<ProjectVm>>
    {
        private readonly IHRMOptimusDbContext _context;
        private readonly IUserContextService _userContextService;

        public ProjectsEmployeeQueryQueryQueryHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<List<ProjectVm>> Handle(ProjectsEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employeeId = _userContextService.GetEmployeeId.Value;

            var projects = await _context.Projects
                .Include(x => x.ProjectMembers)
                .Where(x => x.ProjectMembers.Any(x => x.Id == employeeId))
                .Where(x => x.Enabled)
                .Select(x => new ProjectVm(x.Id, x.Name, x.Description, x.HoursBudget, x.HoursWorked, x.DateFrom, x.DateTo, x.ColorLabel))
                .ToListAsync();

            return projects;
        }
    }
}