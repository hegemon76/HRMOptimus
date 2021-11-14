using MediatR;

namespace HRMOptimus.Application.Employee.Query.EmployeeDetails
{
    public class EmployeeDetailsQuery : IRequest<EmployeeDetailsVm>
    {
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
    }
}