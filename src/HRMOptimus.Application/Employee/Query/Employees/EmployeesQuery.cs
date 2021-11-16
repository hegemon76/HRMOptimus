using MediatR;
using System.Collections.Generic;

namespace HRMOptimus.Application.Employee.Query.Employees
{
    public class EmployeesQuery : IRequest<List<EmployeeVm>>
    {
    }
}