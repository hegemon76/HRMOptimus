﻿using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})

            // Adding Jwt Bearer
            //.AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudience = configuration["JWT:ValidAudience"],
            //        ValidIssuer = configuration["JWT:ValidIssuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            //    };
            //});

            services.AddScoped<IHRMOptimusDbContext>(provider => provider.GetService<HRMOptimusDbContext>());

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HRMOptimusDbContext>();

            return services;
        }
    }
}