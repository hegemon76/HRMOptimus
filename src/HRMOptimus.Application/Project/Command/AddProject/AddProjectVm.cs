using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.Project.Command.AddProject
{
    public class AddProjectVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal HoursBudget { get; set; }
        public string ColorLabel { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime? Deadline { get; set; }
        public ICollection<Domain.Entities.Employee> ProjectMembers { get; set; }
    }
}