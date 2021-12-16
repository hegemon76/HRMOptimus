﻿using HRMOptimus.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        //employee
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }

        //contract
        public string ContractName { get; set; }

        public decimal LeaveDays { get; set; }
        public decimal Payment { get; set; }
        public decimal Rate { get; set; }
        public int WorkTime { get; set; }
        public ContractType ContractType { get; set; }

        //address
        public string ZipCode { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Country { get; set; }

        //role
        public List<UserRoles> Roles { get; set; }
    }
}