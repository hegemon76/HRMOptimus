using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Command.AddEmployee
{
    public class AddEmployeeVmValidator : AbstractValidator<AddEmployeeVm>
    {
        public AddEmployeeVmValidator(IHRMOptimusDbContext dbContext)
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