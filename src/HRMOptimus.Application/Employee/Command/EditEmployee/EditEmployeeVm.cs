using HRMOptimus.Application.Account.Command.Registration;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.Employee.Command.EditEmployee
{
    public class EditEmployeeVm
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }

        //address
        public string ZipCode { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Country { get; set; }
        
    }
}