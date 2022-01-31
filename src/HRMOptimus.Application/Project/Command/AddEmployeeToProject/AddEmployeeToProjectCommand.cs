using MediatR;

namespace HRMOptimus.Application.Project.Command.AddEmployeeToProject
{
    public class AddEmployeeToProjectCommand : IRequest
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}