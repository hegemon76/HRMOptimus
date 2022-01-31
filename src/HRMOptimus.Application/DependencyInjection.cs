using FluentValidation;
using FluentValidation.AspNetCore;
using HRMOptimus.Application.Account.Command.ChangeEmail;
using HRMOptimus.Application.Account.Command.ConfirmEmail;
using HRMOptimus.Application.Account.Command.Password.ChangePassword;
using HRMOptimus.Application.Account.Command.Password.ConfirmPassword;
using HRMOptimus.Application.Account.Command.Registration;
using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Middleware;
using HRMOptimus.Application.Common.Services;
using HRMOptimus.Application.Employee.Command.EditContract;
using HRMOptimus.Application.Employee.Command.EditEmployee;
using HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister;
using HRMOptimus.Application.Project.Command.AddEmployeeToProject;
using HRMOptimus.Application.Project.Command.AddProject;
using HRMOptimus.Application.Project.Command.RemoveEmployeeFromProject;
using HRMOptimus.Application.Project.Command.RemoveProject;
using HRMOptimus.Application.Project.Command.UpdateProject;
using HRMOptimus.Application.WorkRecord.Command.AddWorkRecord;
using HRMOptimus.Application.WorkRecord.Command.RemoveWorkRecord;
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
            services.AddScoped<IDecodeTokenService, DecodeTokenService>();
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<ICreateTokenService, CreateTokenService>().Configure<IConfiguration>((config) =>
             {
                 configuration.GetSection("TokenKey").Bind(config);
             });
            services.AddScoped<EmailService>();

            services.AddScoped<IValidator<RegistrationVm>, RegistrationVmValidator>();
            services.AddScoped<IValidator<UpdateProjectVm>, UpdateProjectVmValidator>();
            services.AddScoped<IValidator<AddProjectVm>, AddProjectVmValidator>();
            services.AddScoped<IValidator<AddWorkRecordVm>, AddWorkRecordVmValidator>();
            services.AddScoped<IValidator<UpdateWorkRecordVm>, UpdateWorkRecordVmValidator>();
            services.AddScoped<IValidator<EditEmployeeVm>, EditEmployeeVmValidator>();
            services.AddScoped<IValidator<RemoveWorkRecordCommand>, RemoveWorkRecordCommandValidator>();
            services.AddScoped<IValidator<AddEmployeeToProjectCommand>, AddEmployeeToProjectCommandValidator>();
            services.AddScoped<IValidator<RemoveEmployeeFromProjectCommand>, RemoveEmployeeFromProjectCommandValidator>();
            services.AddScoped<IValidator<RemoveProjectCommand>, RemoveProjectCommandValidator>();
            services.AddScoped<IValidator<ChangeStatusLeaveRegisterVm>, ChangeStatusLeaveRegisterVmValidator>();
            services.AddScoped<IValidator<EditContractVm>, EditContractValidator>();
            services.AddScoped<IValidator<ChangeEmailVm>, ChangeEmailValidator>();
            services.AddScoped<IValidator<ConfirmEmailCommand>, ConfirmEmailValidator>();
            services.AddScoped<IValidator<ChangePasswordVm>, ChangePasswordValidator>();
            services.AddScoped<IValidator<ConfirmPasswordCommand>, ConfirmPasswordValidator>();

            return services;
        }
    }
}