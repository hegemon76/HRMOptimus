using HRMOptimus.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRMOptimus.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRMOptimusDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStringName")));

            services.AddScoped<IHRMOptimusDbContext>(provider => provider.GetService<HRMOptimusDbContext>());
            return services;
        }
    }
}