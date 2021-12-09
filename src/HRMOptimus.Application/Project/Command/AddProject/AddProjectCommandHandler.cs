using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Command.AddProject
{
    public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;

        public AddProjectCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Domain.Entities.Project()
            {
                Name = request.AddProjectVm.Name,
                DateFrom = request.AddProjectVm.DateFrom,
                DateTo = request.AddProjectVm.DateTo,
                Deadline = request.AddProjectVm.Deadline,
                Description = request.AddProjectVm.Description,
                ProjectMembers = request.AddProjectVm.ProjectMembers,
                HoursBudget = request.AddProjectVm.HoursBudget,
                ColorLabel = request.AddProjectVm.ColorLabel,
            };
            _context.Projects.Add(project);

            await _context.SaveChangesAsync(cancellationToken);
            return project.Id;
        }
    }
}