using HRMOptimus.Application.Common.Models;
using MediatR;

namespace HRMOptimus.Application.Employee.Query.Employees
{
    public class EmployeesQuery : IRequest<PageResult<EmployeeVm>>
    {
        public SearchQuery Query { get; set; }
    }
}