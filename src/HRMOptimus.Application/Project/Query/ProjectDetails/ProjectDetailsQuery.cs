using MediatR;

namespace HRMOptimus.Application.Project.Query.ProjectDetails
{
    public class ProjectDetailsQuery : IRequest<ProjectDetailsVm>
    {
        public int ProjectId { get; set; }
    }
}