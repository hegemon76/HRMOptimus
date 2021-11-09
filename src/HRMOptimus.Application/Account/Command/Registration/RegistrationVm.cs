using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationVm
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //employee
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int LeaveDaysLeft { get; set; }
        public decimal WorkingTime { get; set; }

        //contract
        public string Name { get; set; }
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
    }
}
