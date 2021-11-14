using HRMOptimus.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.Project.Command.AddProject
{
    public class AddProjectVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal HoursBudget { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime? Deadline { get; set; }
        public ICollection<Employee> ProjectMembers { get; set; }
    }
}