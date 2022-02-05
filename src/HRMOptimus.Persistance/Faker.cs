using Bogus;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Persistance
{
    public class Faker
    {
        public static async Task SeedEmployees(HRMOptimusDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            if (await dbContext.Users.AnyAsync())
            {
                return;
            }

            var positions = new[] { "HumanResources", "ProjectManager", "Administrator", "User" };

            var addresFaker = new Faker<Address>(locale: "pl_PL")
                .RuleFor(x => x.City, x => x.Person.Address.City)
                .RuleFor(x => x.Street, x => x.Person.Address.Street)
                .RuleFor(x => x.ZipCode, x => x.Person.Address.ZipCode);

            var contractFaker = new Faker<Contract>()
                .RuleFor(x => x.ContractName, x => x.PickRandom(positions))
                .RuleFor(x => x.Rate, x => x.Random.Decimal(20, 45))
                .RuleFor(x => x.LeaveDays, x => x.Random.Decimal(1, 26));

            var employeeFaker = new Faker<Employee>()
                .RuleFor(x => x.BirthDate, x => x.Person.DateOfBirth)
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.FullName, x => x.Person.FullName)
                .RuleFor(x => x.Address, addresFaker.Generate())
                .RuleFor(x => x.LeaveDaysLeft, x => x.Random.Decimal(0, 26))
                .RuleFor(x => x.Contract, contractFaker.Generate())
                ;

            var applicationUserFaker = new Faker<ApplicationUser>()
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.NormalizedEmail, x => x.Person.Email.ToUpper())
                .RuleFor(x => x.UserName, x => x.Person.Email)
                .RuleFor(x => x.PhoneNumber, x => x.Person.Phone)
                .RuleFor(x => x.NormalizedUserName, x => x.Person.Email.ToUpper())
                .RuleFor(x => x.Employee, employeeFaker.Generate());

            var applicationUsersFaker = applicationUserFaker.Generate(5);
            var password = "!Password1234";
            foreach (var user in applicationUsersFaker)
            {
                var role = user.Employee.Contract.ContractName;
                var result = await userManager.CreateAsync(user, password);

                if (user.Employee.Contract.ContractName == "User")
                {
                    user.Employee.Contract.ContractName = "Developer";
                }

                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(user, new List<string>() { role });
                    await dbContext.SaveChangesAsync(CancellationToken.None);
                }
            }
            var employees = dbContext.Employees.ToList();
            var projectFaker = new Faker<Project>()
                .RuleFor(x => x.Name, x => x.Company.CompanyName())
                .RuleFor(x => x.HoursBudget, x => x.Random.Int(50, 1000))
                .RuleFor(x => x.DateFrom, DateTime.Now)
                .RuleFor(x => x.DateTo, DateTime.Now.AddMonths(5))
                .RuleFor(x => x.ColorLabel, "#2ed42b")
                .RuleFor(x => x.Description, x => x.Lorem.Lines(1))
                .RuleFor(x => x.ProjectMembers, x => x.PickRandom(employees, 3));

            var projectsFaker = projectFaker.Generate(10);

            await dbContext.Projects.AddRangeAsync(projectsFaker);
            await dbContext.SaveChangesAsync(CancellationToken.None);

            var random = new Random();

            var workRecordFaker = new Faker<WorkRecord>()
               .RuleFor(x => x.WorkStart, x => x.Date.BetweenOffset(DateTime.Now.AddMonths(-1), DateTime.Now))
               .RuleFor(x => x.Name, x => x.Lorem.Lines(1))
               .RuleFor(x => x.Project, x => projectsFaker[x.Random.Int(0, projectsFaker.Count - 1)])
               .RuleFor(x => x.Employee, x => employees[x.Random.Int(0, employees.Count - 1)]);

            var workRecordsFaker = workRecordFaker.Generate(300);

            foreach (var workRecord in workRecordsFaker)
            {
                workRecord.WorkEnd = workRecord.WorkStart.AddMinutes(random.Next(5, 120));
            }

            await dbContext.WorkRecords.AddRangeAsync(workRecordsFaker);
            await dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}