using FluentValidation;
using FluentValidation.AspNetCore;
using HRMOptimus.Application.Account.Command.Registration;
using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Middleware;
using HRMOptimus.Application.Common.Services;
using HRMOptimus.Application.Project.Command.AddProject;
using HRMOptimus.Application.Project.Command.UpdateProject;
using HRMOptimus.Application.WorkRecord.Command.AddWorkRecord;
using HRMOptimus.Application.WorkRecord.Command.UpdateWorkRecord;
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
            services.AddControllers().AddFluentValidation();
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

            services.AddScoped<IValidator<RegistrationVm>, RegistrationVmValidator>();
            services.AddScoped<IValidator<UpdateProjectVm>, UpdateProjectVmValidator>();
            services.AddScoped<IValidator<AddProjectVm>, AddProjectVmValidator>();
            services.AddScoped<IValidator<AddWorkRecordVm>, AddWorkRecordVmValidator>();
            services.AddScoped<IValidator<UpdateWorkRecordVm>, UpdateWorkRecordVmValidator>();

            return services;
        }
    }
}