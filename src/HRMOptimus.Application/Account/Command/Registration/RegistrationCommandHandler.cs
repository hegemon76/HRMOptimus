using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _context;

        public RegistrationCommandHandler(UserManager<ApplicationUser> userManager, IHRMOptimusDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var user = _userManager.FindByEmailAsync(request.Registration.Email);
                if (user == null)
                {
                    Contract contract = new Contract()
                    {
                        Name = request.Registration.Name,
                        LeaveDays = request.Registration.LeaveDays,
                        Payment = request.Registration.Payment,
                        Rate = request.Registration.Rate,
                        WorkTime = request.Registration.WorkTime,
                        ContractType = request.Registration.ContractType
                    };

                    Address address = new Address()
                    {
                        ZipCode = request.Registration.ZipCode,
                        City = request.Registration.City,
                        Street = request.Registration.Street,
                        BuildingNumber = request.Registration.BuildingNumber,
                        HouseNumber = request.Registration.HouseNumber,
                        Country = request.Registration.Country
                    };


                    Employee employee = new Employee()
                    {
                        FirstName = request.Registration.Email,
                        LastName = request.Registration.LastName,
                        BirthDate = request.Registration.BirthDate,
                        LeaveDaysLeft = (int)contract.LeaveDays,
                        Contract = contract,
                        Address = address,
                        Projects = new List<Project>(),
                        WorkRecords = new List<WorkRecord>(),
                        LeavesRegister = new List<LeaveRegister>()
                        
                    };
                    employee.ComputeFullName();

                    contract.Employee = employee;
                    address.Employee = employee;

                    _context.Contracts.Add(contract);
                    _context.Addresses.Add(address);

                    employee.ContractId = contract.Id;
                    employee.AddressId = address.Id;

                    _context.Employees.Add(employee);

                    var newUser = new ApplicationUser()
                    {
                        UserName = request.Registration.Email,
                        Email = request.Registration.Email,
                        EmployeeId = employee.Id,
                        Employee = employee,
                        Enabled = true
                    };
                    await _userManager.CreateAsync(newUser, request.Registration.Password);
                    await _context.SaveChangesAsync(cancellationToken);
                    return newUser.Id;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
