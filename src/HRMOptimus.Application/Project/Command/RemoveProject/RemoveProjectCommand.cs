using MediatR;

namespace HRMOptimus.Application.Project.Command.RemoveProject
{
    public class RemoveProjectCommand : IRequest
    {
        public int ProjectId { get; set; }
    }
}