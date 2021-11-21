using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using System;

namespace HRMOptimus.Application.Employee.Query.EmployeeDetails
{
    public record EmployeeDetailsVm(string FirstName, string LastName, string FullName, Gender Gender, DateTime? BirthDate,
        decimal LeaveDaysLeft, decimal WorkingTime, Contract Contract, Address Address, string Email, string PhoneNumber);
}