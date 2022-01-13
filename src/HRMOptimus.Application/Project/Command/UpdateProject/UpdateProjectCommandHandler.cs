using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Command.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IHRMOptimusDbContext _context;

        public UpdateProjectCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FindAsync(request.UpdateProjectVm.Id);

            project.Name = request.UpdateProjectVm.Name;
            project.DateFrom = request.UpdateProjectVm.DateFrom;
            project.DateTo = request.UpdateProjectVm.DateTo;
            project.Deadline = request.UpdateProjectVm.Deadline;
            project.Description = request.UpdateProjectVm.Description;
            project.ProjectMembers = request.UpdateProjectVm.ProjectMembers;
            project.HoursBudget = request.UpdateProjectVm.HoursBudget;
            project.ColorLabel = request.UpdateProjectVm.ColorLabel;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}