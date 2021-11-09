using Microsoft.AspNetCore.Identity;
using System;

namespace HRMOptimus.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string InactivatedBy { get; set; }
        public DateTime? InactivatedOn { get; set; }
        public bool Enabled { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
