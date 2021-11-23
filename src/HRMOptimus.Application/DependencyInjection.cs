using HRMOptimus.Application.Common.Middleware;
using HRMOptimus.Application.Common.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRMOptimus.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<RequestTimeMiddleware>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<TokenService>().Configure<IConfiguration>((config) =>
            {
                configuration.GetSection("TokenKey").Bind(config);
            });

            return services;
        }
    }
}