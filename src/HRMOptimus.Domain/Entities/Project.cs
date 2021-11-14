using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMOptimus.Domain.Entities
{
    public class Project : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursBudget { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursWorked { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime? Deadline { get; set; }
        public ICollection<Employee> ProjectMembers { get; set; }
        public ICollection<WorkRecord> WorkRekords { get; set; }
    }
}
