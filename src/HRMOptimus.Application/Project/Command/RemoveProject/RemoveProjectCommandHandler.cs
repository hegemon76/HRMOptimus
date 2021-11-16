using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Command.RemoveProject
{
    public class RemoveProjectCommandHandler : IRequestHandler<RemoveProjectCommand>
    {
        private readonly IHRMOptimusDbContext _context;

        public RemoveProjectCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.ProjectId);

            if (project == null)
                throw new NotFoundException("There is no work record with Id: " + request.ProjectId);

            project.Enabled = false;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}