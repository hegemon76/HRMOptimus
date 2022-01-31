﻿using Microsoft.AspNetCore.Identity;
using System;

namespace HRMOptimus.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string NewMail { get; set; }
        public string NewPassword { get; set; }
    }
}
