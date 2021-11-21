using MediatR;
using System.Collections.Generic;

namespace HRMOptimus.Application.Project.Query.Projects
{
    public class ProjectsQuery : IRequest<List<ProjectVm>>
    {
    }
}