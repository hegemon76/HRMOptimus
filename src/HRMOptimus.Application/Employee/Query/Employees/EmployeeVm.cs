﻿using HRMOptimus.Domain.Enums;
using System;

namespace HRMOptimus.Application.Employee.Query.Employees
{
    public record EmployeeVm(int Id, string FirstName, string LastName, string FullName, Gender Gender, DateTime? BirthDate, string Email, string PhoneNumber);
}