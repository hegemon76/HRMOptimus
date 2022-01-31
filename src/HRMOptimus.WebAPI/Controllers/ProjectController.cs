using HRMOptimus.Application.Project.Command.AddEmployeeToProject;
using HRMOptimus.Application.Project.Command.AddProject;
using HRMOptimus.Application.Project.Command.RemoveEmployeeFromProject;
using HRMOptimus.Application.Project.Command.RemoveProject;
using HRMOptimus.Application.Project.Command.UpdateProject;
using HRMOptimus.Application.Project.Query.ProjectDetails;
using HRMOptimus.Application.Project.Query.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class ProjectController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "Administrator, ProjectManager")]
        [Route("api/project/add")]
        public async Task<ActionResult<int>> AddProject(AddProjectVm model)
        {
            var id = await Mediator.Send(new AddProjectCommand() { AddProjectVm = model });

            return id;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, ProjectManager")]
        [Route("api/project/addEmployee")]
        public async Task<ActionResult> AddEmployeeToProject(int projectId, int employeeId)
        {
            await Mediator.Send(new AddEmployeeToProjectCommand() { EmployeeId = employeeId, ProjectId = projectId });

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator, ProjectManager")]
        [Route("api/project/removeEmployeeFromProject")]
        public async Task<ActionResult> RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            await Mediator.Send(new RemoveEmployeeFromProjectCommand() { EmployeeId = employeeId, ProjectId = projectId });

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Administrator, ProjectManager")]
        [Route("api/project/update")]
        public async Task<ActionResult> UpdateProject(UpdateProjectVm model)
        {
            await Mediator.Send(new UpdateProjectCommand() { UpdateProjectVm = model });

            return Ok();
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
        [Authorize(Roles = "Administrator, ProjectManager")]
        [Route("api/project/delete/")]
        public async Task<ActionResult> RemoveProject(int projectId)
        {
            await Mediator.Send(new RemoveProjectCommand() { ProjectId = projectId });

            return NoContent();
        }
    }
}