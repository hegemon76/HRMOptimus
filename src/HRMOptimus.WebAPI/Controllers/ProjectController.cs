using HRMOptimus.Application.Project.Command.AddProject;
using HRMOptimus.Application.Project.Command.RemoveProject;
using HRMOptimus.Application.Project.Query.ProjectDetails;
using HRMOptimus.Application.Project.Query.Projects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [ApiController]
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
        public async Task<ActionResult<List<ProjectVm>>> GetProjects()
        {
            var projects = await Mediator.Send(new ProjectsQuery());

            return projects;
        }

        [HttpDelete]
        [Route("api/project/delete/")]
        public async Task<ActionResult> RemoveProject(int projectId)
        {
            await Mediator.Send(new RemoveProjectCommand() { ProjectId = projectId });

            return NoContent();
        }
    }
}