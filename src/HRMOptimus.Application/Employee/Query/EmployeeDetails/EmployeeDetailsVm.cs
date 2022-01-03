using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.Employee.Query.EmployeeDetails
{
    public record EmployeeDetailsVm(string FirstName, string LastName, string FullName, Gender Gender, DateTime? BirthDate,
        decimal LeaveDaysLeft, decimal WorkingTime, Contract Contract, Address Address, string Email, string PhoneNumber, List<string> roles);
}