using MediatR;

namespace HRMOptimus.Application.Project.Command.RemoveEmployeeFromProject
{
    public class RemoveEmployeeFromProjectCommand : IRequest
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}