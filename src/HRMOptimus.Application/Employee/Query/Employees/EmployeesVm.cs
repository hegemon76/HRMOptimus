using System.Collections.Generic;

namespace HRMOptimus.Application.Employee.Query.Employees
{
    public record EmployeesVm(List<Domain.Entities.Employee> Employees);
}