using FluentAssertions;
using HRMOptimus.Application.WorkRecord.Command.AddWorkRecord;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using HRMOptimus.Persistance;
using HRMOptimus.WebAPI.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HRMOptimus.WebAPI.IntegrationTests.Controllers
{
    public class WorkRecordControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        private string _baseUrl = "/api/workrecord/";

        public WorkRecordControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<HRMOptimusDbContext>));
                        services.Remove(dbContextOptions);

                        services.AddDbContext<HRMOptimusDbContext>(options => options.UseInMemoryDatabase("HRMOptimusDb"));
                    });
                });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task WorkDayRecords_Day_ReturnsOkResult()
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HRMOptimusDbContext>();

            var project = new Project() { Name = "test", DateTo = DateTime.Now, DateFrom = DateTime.Now, HoursBudget = 5, HoursWorked = 1 };
            var employee = new Employee() { FirstName = "test", Gender = Gender.Man, WorkingTime = 168, LeaveDaysLeft = 2 };
            await dbContext.Projects.AddAsync(project);
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync(CancellationToken.None);

            var workRecord = new WorkRecord()
            {
                EmployeeId = employee.Id,
                Name = "Test",
                WorkStart = DateTime.Now,
                WorkEnd = DateTime.Now.AddMinutes(15),
                ProjectId = project.Id,
            };
            await dbContext.WorkRecords.AddAsync(workRecord);

            var today = DateTime.Now.Date.ToString();
            var response = await _client.GetAsync(_baseUrl + "day?" + today);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddWorkRecord_WithValidModel_ReturnsOkResultWithId()
        {
            var url = _baseUrl + "add";

            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HRMOptimusDbContext>();

            var project = new Project() { Name = "test", DateTo = DateTime.Now, DateFrom = DateTime.Now, HoursBudget = 5, HoursWorked = 1 };
            var employee = new Employee() { FirstName = "test", Gender = Gender.Man, WorkingTime = 168, LeaveDaysLeft = 2 };
            await dbContext.Projects.AddAsync(project);
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync(CancellationToken.None);

            var model = new AddWorkRecordVm()
            {
                EmployeeId = employee.Id,
                Name = "Test1",
                WorkStart = DateTime.Now,
                WorkEnd = DateTime.Now.AddMinutes(15),
                ProjectId = project.Id,
            };
            var httpContent = model.ToJsonHttpContent();

            var response = await _client.PostAsync(url, httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}