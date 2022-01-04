using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System;
using System.Linq;

namespace HRMOptimus.Application.Employee.Command.EditEmployee
{
    public class EditEmployeeVmValidator : AbstractValidator<EditEmployeeVm>
    {
        public EditEmployeeVmValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.EmployeeId).NotEmpty().Custom((value, context) =>
            {
                var employee = dbContext.Employees.Any(e => e.Id == value && e.Enabled);
                if (!employee)
                    context.AddFailure("Id", "The Employee with Id: " + value + " doesn't exist");
            });

            RuleFor(x => x.Gender).Custom((gender, context) =>
            {
                if (!Enum.IsDefined(gender.Value))
                    context.AddFailure($"Gender with given Id = {gender.Value} is not defined");
            });
        }
    }
}