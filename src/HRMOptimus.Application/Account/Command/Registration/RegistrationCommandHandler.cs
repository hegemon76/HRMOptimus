﻿using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _context;

        public RegistrationCommandHandler(UserManager<ApplicationUser> userManager, IHRMOptimusDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Unit> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            Contract contract = new Contract()
            {
                ContractName = request.Registration.ContractName,
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

            var employee = new Domain.Entities.Employee()
            {
                FirstName = request.Registration.FirstName,
                LastName = request.Registration.LastName,
                BirthDate = request.Registration.BirthDate,
                WorkingTime = 0,
                LeaveDaysLeft = (int)contract.LeaveDays,
                Contract = contract,
                Gender = request.Registration.Gender,
                Address = address,
                FullName = $"{request.Registration.FirstName} {request.Registration.LastName}",
                Projects = new List<Domain.Entities.Project>(),
                WorkRecords = new List<Domain.Entities.WorkRecord>(),
                LeavesRegister = new List<Domain.Entities.LeaveRegister>()
            };

            _context.Contracts.Add(contract);
            _context.Addresses.Add(address);

            employee.ContractId = contract.Id;
            employee.AddressId = address.Id;
            _context.Employees.Add(employee);

            var newUser = new ApplicationUser()
            {
                UserName = request.Registration.Email,
                Email = request.Registration.Email,
                PhoneNumber = request.Registration.PhoneNumber,
                Employee = employee,
            };

            var user = await _userManager.CreateAsync(newUser, request.Registration.Password);

            if (user.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.Administrator.ToString());

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}