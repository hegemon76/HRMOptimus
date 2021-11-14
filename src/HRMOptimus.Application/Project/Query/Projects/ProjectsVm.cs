using HRMOptimus.Application.Project.Query.ProjectDetails;
using System.Collections.Generic;

namespace HRMOptimus.Application.Project.Query.Projects
{
    public record ProjectsVm(List<ProjectDetailsVm> Projects);
}