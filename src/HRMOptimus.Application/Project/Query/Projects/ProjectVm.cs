using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.Project.Query.Projects
{
    public record ProjectVm(int Id, string Name, string Description, decimal HoursWorked, DateTime DateFrom,
        DateTime DateTo, string ColorLabel);
}