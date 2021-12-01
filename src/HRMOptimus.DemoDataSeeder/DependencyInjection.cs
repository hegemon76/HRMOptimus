using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.DemoDataSeeder.Customizations;
using HRMOptimus.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace HRMOptimus.DemoDataSeeder
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomizations(this IServiceCollection services)
        {
            services.AddScoped<DemoDataSeederCustomization>();
            services.AddScoped<IHRMOptimusDbContext, HRMOptimusDbContext>();

            return services;
        }
    }
}