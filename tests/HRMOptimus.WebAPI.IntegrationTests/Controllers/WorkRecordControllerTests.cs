using FluentAssertions;
using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Persistance;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRMOptimus.WebAPI.IntegrationTests.Controllers
{
    public class WorkRecordControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;

        private string _baseUrl = "api/workrecord/";

        public WorkRecordControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<HRMOptimusDbContext>));
                        services.Remove(dbContextOptions);

                        services.AddDbContext<HRMOptimusDbContext>(options => options.UseInMemoryDatabase("HRMOptimusDb"));
                    });
                })
                .CreateClient();
        }

        //[Fact]
        //public async Task WorkDayRecords_Day_ReturnsOkResult()
        //{
        //    var response = await _client.GetAsync(_baseUrl + "day/2021-12-11");

        //    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        //}
    }
}