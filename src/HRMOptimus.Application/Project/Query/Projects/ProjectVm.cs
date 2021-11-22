using System;

namespace HRMOptimus.Application.Project.Query.Projects
{
    public record ProjectVm(string Name, string Description, decimal HoursWorked, DateTime DateFrom,
        DateTime DateTo);
}