using HRMOptimus.Application.Project.Query.Projects;
using MediatR;
using System.Collections.Generic;

namespace HRMOptimus.Application.Project.Query.ProjectsEmployee
{
    public class ProjectsEmployeeQuery : IRequest<List<ProjectVm>>
    {
    }
}