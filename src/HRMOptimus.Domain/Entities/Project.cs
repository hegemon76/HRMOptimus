using HRMOptimus.Domain.Common;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Domain.Entities
{
    public class Project : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal HoursBudget { get; set; }
        public decimal HoursWorked { get; set; }
        public string ColorLabel { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime? Deadline { get; set; }
        public ICollection<Employee> ProjectMembers { get; set; }
        public ICollection<WorkRecord> WorkRekords { get; set; }
    }
}