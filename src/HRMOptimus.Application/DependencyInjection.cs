using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Middleware;
using HRMOptimus.Application.Common.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

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
            services.AddHttpContextAccessor();
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<TokenService>().Configure<IConfiguration>((config) =>
            {
                configuration.GetSection("TokenKey").Bind(config);
            });

            return services;
        }
    }
}