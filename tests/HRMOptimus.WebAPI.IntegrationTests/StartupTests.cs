using FluentAssertions;
using HRMOptimus.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HRMOptimus.WebAPI.IntegrationTests
{
    public class StartupTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly List<Type> _controllerTypes;
        private readonly WebApplicationFactory<Startup> _factory;

        public StartupTests(WebApplicationFactory<Startup> factory)
        {
            _controllerTypes = typeof(Startup)
                .Assembly
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(BaseController)))
                .ToList();

            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    _controllerTypes.ForEach(x => services.AddScoped(x));
                });
            });
        }

        [Fact]
        public void ConfigureServices_ForControllers_RegisterAllDependencies()
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            _controllerTypes.ForEach(t =>
            {
                var controller = scope.ServiceProvider.GetService(t);
                controller.Should().NotBeNull();
            });
        }
    }
}