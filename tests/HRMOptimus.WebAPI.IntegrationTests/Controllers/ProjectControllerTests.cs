using FluentAssertions;
using HRMOptimus.Application.Project.Command.AddProject;
using HRMOptimus.Application.Project.Command.UpdateProject;
using HRMOptimus.Domain.Entities;
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
    public class ProjectControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private Project _project;
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        private string _baseUrl = "/api/project/";

        public ProjectControllerTests(WebApplicationFactory<Startup> factory)
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
        public async Task AddProject_WithValidModel_ReturnsOkResultWithId()
        {
            var url = _baseUrl + "add";

            var model = new AddProjectVm()
            {
                Name = "testName",
                DateTo = DateTime.Now.AddDays(2),
                DateFrom = DateTime.Now,
                Deadline = DateTime.Now.AddDays(2),
                HoursBudget = 5
            };

            var httpContent = model.ToJsonHttpContent();

            var response = await _client.PostAsync(url, httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddProject_WithInvalidModel_ReturnsBadRequest()
        {
            var url = _baseUrl + "add";

            var model = new AddProjectVm()
            {
                DateTo = DateTime.Now,
                DateFrom = DateTime.Now,
                HoursBudget = 5
            };

            var httpContent = model.ToJsonHttpContent();

            var response = await _client.PostAsync(url, httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateProject_UpdatedProject_ReturnsOk()
        {
            var url = _baseUrl + "update?projectId=1";

            await SeedProject();

            var model = new UpdateProjectVm()
            {
                Id = 1,
                Name = "NewtestName",
                DateTo = DateTime.Now.AddDays(2),
                DateFrom = DateTime.Now,
                Deadline = DateTime.Now.AddDays(2),
                HoursBudget = 5
            };

            var httpContent = model.ToJsonHttpContent();

            var response = await _client.PutAsync(url, httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateProject_InvalidUpdatedProject_ReturnsBadRequest()
        {
            var url = _baseUrl + "update?projectId=1";

            await SeedProject();

            var model = new UpdateProjectVm()
            {
                Id = 1,
                Name = "NewtestName",
                DateTo = DateTime.Now,
                DateFrom = DateTime.Now,
            };

            var httpContent = model.ToJsonHttpContent();

            var response = await _client.PutAsync(url, httpContent);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetProjectDetails_ValidId_ReturnsOKResult()
        {
            var url = _baseUrl + "details?projectId=1";

            await SeedProject();

            var response = await _client.GetAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetProjectDetails_InvalidId_ReturnsNotFound()
        {
            var url = _baseUrl + "details?projectId=900";

            await SeedProject();

            var response = await _client.GetAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetProjects_ReturnsOKResult()
        {
            var url = "api/projects";

            await SeedProject();

            var response = await _client.GetAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task RemoveProject_ValidId_ReturnsNoContent()
        {
            var url = _baseUrl + "delete?projectId=1";

            await SeedProject();

            var response = await _client.DeleteAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task RemoveProject_InvalidId_ReturnsNotFound()
        {
            var url = _baseUrl + "delete?projectId=900";

            await SeedProject();

            var response = await _client.DeleteAsync(url);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        private async Task SeedProject()
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HRMOptimusDbContext>();

            _project = new Project() { Name = "testName", DateTo = DateTime.Now, DateFrom = DateTime.Now, HoursBudget = 5, HoursWorked = 1 };
            await dbContext.Projects.AddAsync(_project);

            await dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}