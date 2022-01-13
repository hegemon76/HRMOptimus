using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.Project.Command.UpdateProject
{
    public class UpdateProjectVm
    {
        public int Id { get; set; }
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