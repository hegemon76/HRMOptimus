using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.Project.Command.AddEmployeeToProject
{
    public class AddEmployeeToProjectCommandValidator : AbstractValidator<AddEmployeeToProjectCommand>
    {
        public AddEmployeeToProjectCommandValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.ProjectId)
               .Custom((value, context) =>
               {
                   var project = dbContext.Projects.Any(e => e.Id == value && e.Enabled);
                   if (!project)
                       context.AddFailure("Id", "The Project with Id: " + value + " doesn't exist");
               });

            RuleFor(x => x.EmployeeId)
               .Custom((value, context) =>
               {
                   var project = dbContext.Employees.Any(e => e.Id == value && e.Enabled);
                   if (!project)
                       context.AddFailure("Id", "The Employee with Id: " + value + " doesn't exist");
               });
        }
    }
}