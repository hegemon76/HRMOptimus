using FluentAssertions;
using HRMOptimus.Application.Account.Command.Registration;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using HRMOptimus.Persistance;
using HRMOptimus.WebAPI.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HRMOptimus.WebAPI.IntegrationTests.Controllers
{
    public class AccountControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        private string _baseUrl = "/api/";

        public AccountControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<HRMOptimusDbContext>));
                        services.Remove(dbContextOptions);
                        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                        services.AddMvc(option => option.Filters.Add(new FakeUserFilter()));

                        services.AddDbContext<HRMOptimusDbContext>(options => options.UseInMemoryDatabase("HRMOptimusDb"));
                    });
                });

            _client = _factory.CreateClient();
        }

        //[Fact]
        //public async Task Register_WithValidModel_ReturnsOkResult()
        //{
        //    var url = _baseUrl + "register";
        //    // await SeedRoles();
        //    var model = new RegistrationVm()
        //    {
        //        Email = "test@email.com",
        //        Password = "!GoodPassword123",
        //        PhoneNumber = "777-777-777",
        //        FirstName = "TestLastName",
        //        Gender = Gender.Man,
        //        ContractName = "TestContractName",
        //        ContractType = ContractType.UoP,
        //        Roles = new List<UserRoles>() { UserRoles.Administrator },
        //        LeaveDays = 5,
        //        Payment = 5,
        //        Rate = 5,
        //        WorkTime = 5,
        //        City = "TestCity",
        //        LastName = "TestFirstName",
        //        BirthDate = DateTime.Now,
        //    };

        //    var httpContent = model.ToJsonHttpContent();

        //    var response = await _client.PostAsync(url, httpContent);

        //    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        //}

        //private async Task SeedUser()
        //{
        //    var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        //    using var scope = scopeFactory.CreateScope();
        //    var dbContext = scope.ServiceProvider.GetService<HRMOptimusDbContext>();

        //    _user = new Employee() { Name = "testName", DateTo = DateTime.Now, DateFrom = DateTime.Now, HoursBudget = 5, HoursWorked = 1 };
        //    await dbContext.Projects.AddAsync(_project);

        //    await dbContext.SaveChangesAsync(CancellationToken.None);
        //}

        //private async Task SeedRoles()
        //{
        //    var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        //    using var scope = scopeFactory.CreateScope();
        //    var dbContext = scope.ServiceProvider.GetService<HRMOptimusDbContext>();

        //    var roles = new List<IdentityRole>();
        //    roles.Add(new IdentityRole { Name = UserRoles.Administrator.ToString(), NormalizedName = UserRoles.Administrator.ToString() });
        //    roles.Add(new IdentityRole { Name = nameof(UserRoles.User), NormalizedName = nameof(UserRoles.User) });
        //    roles.Add(new IdentityRole { Name = nameof(UserRoles.HumanResources), NormalizedName = nameof(UserRoles.HumanResources) });
        //    roles.Add(new IdentityRole { Name = nameof(UserRoles.ProjectManager), NormalizedName = nameof(UserRoles.ProjectManager) });

        //    await dbContext.IdentityRoles.AddRangeAsync(roles);

        //    await dbContext.SaveChangesAsync(CancellationToken.None);
        //}
    }
}