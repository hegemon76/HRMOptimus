using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Domain.Entities
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal LeaveDaysLeft { get; set; }
        public decimal WorkingTime { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<WorkRecord> WorkRecords { get; set; }
        public ICollection<LeaveRegister> LeavesRegister { get; set; }
    }
}