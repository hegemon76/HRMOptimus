using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HRMOptimus.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRMOptimusDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStringName")));

            services.AddScoped<IHRMOptimusDbContext>(provider => provider.GetService<HRMOptimusDbContext>());

            services.AddIdentityCore<ApplicationUser>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            }
            ).AddRoles<IdentityRole>()
            .AddUserManager<UserManager<ApplicationUser>>()
            .AddEntityFrameworkStores<HRMOptimusDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                   };
               });

            return services;
        }
    }
}