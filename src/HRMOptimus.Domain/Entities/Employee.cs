using HRMOptimus.Domain.Common;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Domain.Entities
{
    public class Employee: EntityBase
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName {  get; set;}
        public string FullName {  get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int MyProperty { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<MonthWork> MonthWorks { get; set; }
        public ICollection<DayWork> DayWorks { get; set; }
        public ICollection<WorkRecord> WorkRecords { get; set; }
        public void ComputeFullName()
        {
            FullName = $"{FirstName} {LastName}";
        }
    }
}
