using MediatR;

namespace HRMOptimus.Application.Project.Command.AddProject
{
    public class AddProjectCommand : IRequest<int>
    {
        public AddProjectVm AddProjectVm { get; set; }
    }
}