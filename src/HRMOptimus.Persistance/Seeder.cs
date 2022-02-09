using HRMOptimus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Persistance
{
    public static class Seeder
    {
        public static async Task SeedAsync(HRMOptimusDbContext _dbContext)
        {
            if (_dbContext.Database.CanConnect())
            {
                if (await _dbContext.Users.AnyAsync())
                    return;

                await SeedUsers(_dbContext);
                await SeedProjects(_dbContext);
                await SeedWorkRecords(_dbContext);
            }
        }

        public static async Task SeedUsers(HRMOptimusDbContext _dbContext)
        {
            if (!await _dbContext.ApplicationUsers.AnyAsync())
            {
                var applicationUserData = File.ReadAllText("./Data/SeederData/applicationUsers.json");
                var employeesData = File.ReadAllText("./Data/SeederData/employees.json");

                var applicationUsers = JsonSerializer.Deserialize<List<ApplicationUser>>(applicationUserData);
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);

                await _dbContext.ApplicationUsers.AddRangeAsync(applicationUsers);
                await _dbContext.Employees.AddRangeAsync(employees);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }
        }

        public static async Task SeedProjects(HRMOptimusDbContext _dbContext)
        {
            if (!await _dbContext.Projects.AnyAsync())
            {
                var projectsData = File.ReadAllText("./Data/SeederData/projects.json");

                var projects = JsonSerializer.Deserialize<List<Project>>(projectsData);

                await _dbContext.Projects.AddRangeAsync(projects);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }
        }

        public static async Task SeedWorkRecords(HRMOptimusDbContext _dbContext)
        {
            if (!await _dbContext.WorkRecords.AnyAsync())
            {
                var workRecordsData = File.ReadAllText("./Data/SeederData/workRecords.json");

                var workRecords = JsonSerializer.Deserialize<List<WorkRecord>>(workRecordsData);

                await _dbContext.WorkRecords.AddRangeAsync(workRecords);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }
        }
    }
}