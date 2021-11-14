using HRMOptimus.Application.Project.Command.AddProject;
using HRMOptimus.Application.Project.Query.ProjectDetails;
using HRMOptimus.Application.Project.Query.Projects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    public class ProjectController : BaseController
    {
        [HttpPost]
        [Route("api/project/add")]
        public async Task<ActionResult<int>> AddProject(AddProjectVm model)
        {
            var id = await Mediator.Send(new AddProjectCommand() { AddProjectVm = model });

            return id;
        }

        [HttpGet]
        [Route("api/project/details")]
        public async Task<ActionResult<ProjectDetailsVm>> GetProjectDetails(int projectId)
        {
            var projectDetails = await Mediator.Send(new ProjectDetailsQuery() { ProjectId = projectId });

            return projectDetails;
        }

        [HttpGet]
        [Route("api/projects")]
        public async Task<ActionResult<ProjectsVm>> GetProjects()
        {
            var projectDetails = await Mediator.Send(new ProjectsQuery());

            return projectDetails;
        }
    }
}