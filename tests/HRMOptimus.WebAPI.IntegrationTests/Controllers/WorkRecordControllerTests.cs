using FluentAssertions;
using HRMOptimus.Application.WorkRecord.Command.AddWorkRecord;
using HRMOptimus.Application.WorkRecord.Command.UpdateWorkRecord;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using HRMOptimus.Persistance;
using HRMOptimus.WebAPI.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Authorization.Policy;
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
        private Project _project;
        private Employee _employee;
        private WorkRecord _workRecord;
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
                        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();

                        services.AddDbContext<HRMOptimusDbContext>(options => options.UseInMemoryDatabase("HRMOptimusDb"));
                    });
                });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task WorkDayRecords_Day_ReturnsOkResult()
        {
            await SeedWorkRecordProjectEmployee();

            var today = DateTime.Now.Date.ToString();
            var response = await _client.GetAsync(_baseUrl + "day?" + today);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task MonthWorkRecords_TwoDates_ReturnsOkResult()
        {
            await SeedWorkRecordProjectEmployee();

            var response = await _client.GetAsync(_baseUrl + "month");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddWorkRecord_WithValidModel_ReturnsOkResultWithId()
        {
            var url = _baseUrl + "add";

            await SeedWorkRecordProjectEmployee();

            var model = new AddWorkRecordVm()
            {
                Name = "Test1",
                WorkStart = DateTime.Now,
                WorkEnd = DateTime.Now.AddMinutes(15),
                ProjectId = _project.Id,
            };
            var httpContent = model.ToJsonHttpContent();

            var response = await _client.PostAsync(url, httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddWorkRecord_WithInvalidModel_ReturnsBadRequest()
        {
            var url = _baseUrl + "add";

            await SeedWorkRecordProjectEmployee();

            var model = new AddWorkRecordVm()
            {
                WorkStart = DateTime.Now,
                WorkEnd = DateTime.Now.AddMinutes(15),
                ProjectId = _employee.Id,
            };
            var httpContent = model.ToJsonHttpContent();

            var response = await _client.PostAsync(url, httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateWorkRecord_UpdatedWorkRecord_ReturnsOkResult()
        {
            var url = _baseUrl + "update";

            await SeedWorkRecordProjectEmployee();

            var model = new UpdateWorkRecordVm()
            {
                Id = 1,
                EmployeeId = _employee.Id,
                Name = "UpdatedName",
                WorkStart = DateTime.Now,
                WorkEnd = DateTime.Now.AddMinutes(15),
                ProjectId = _project.Id,
            };
            var httpContent = model.ToJsonHttpContent();

            var response = await _client.PutAsync(url, httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteWorkRecord_ValidId_ReturnsNoContent()
        {
            await SeedWorkRecordProjectEmployee();

            var url = _baseUrl + "delete?workRecordId=" + _workRecord.Id;

            var response = await _client.DeleteAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteWorkRecord_InvalidId_ReturnsNotFound()
        {
            var url = _baseUrl + "delete?workRecordId=900";

            await SeedWorkRecordProjectEmployee();

            var response = await _client.DeleteAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        private async Task SeedWorkRecordProjectEmployee()
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HRMOptimusDbContext>();

            _project = new Project() { Name = "test", DateTo = DateTime.Now, DateFrom = DateTime.Now, HoursBudget = 5, HoursWorked = 1 };
            _employee = new Employee() { FirstName = "test", Gender = Gender.Man, WorkingTime = 168, LeaveDaysLeft = 2 };
            await dbContext.Projects.AddAsync(_project);
            await dbContext.Employees.AddAsync(_employee);
            _workRecord = new WorkRecord() { EmployeeId = _project.Id, WorkStart = DateTime.Now, WorkEnd = DateTime.Now.AddMinutes(15), ProjectId = _employee.Id };
            await dbContext.WorkRecords.AddAsync(_workRecord);

            await dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}