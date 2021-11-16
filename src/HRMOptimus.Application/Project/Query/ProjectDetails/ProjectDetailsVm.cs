using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.Project.Query.ProjectDetails
{
    public record ProjectDetailsVm(string Name, string Description, decimal HoursBudget, decimal HoursWorked, DateTime DateFrom,
        DateTime DateTo, DateTime? Deadline, ICollection<Domain.Entities.Employee> ProjectMembers);
}