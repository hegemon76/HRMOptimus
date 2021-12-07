using MediatR;

namespace HRMOptimus.Application.Project.Command.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public UpdateProjectVm UpdateProjectVm { get; set; }
    }
}