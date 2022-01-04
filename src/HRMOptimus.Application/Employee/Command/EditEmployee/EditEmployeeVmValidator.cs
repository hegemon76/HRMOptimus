using FluentValidation;
using System;

namespace HRMOptimus.Application.Employee.Command.EditEmployee
{
    public class EditEmployeeVmValidator : AbstractValidator<EditEmployeeVm>
    {
        public EditEmployeeVmValidator()
        {
            RuleFor(x => x.Gender).Custom((gender, context) =>
            {
                if (!Enum.IsDefined(gender.Value))
                    context.AddFailure($"Gender with given Id = {gender.Value} is not defined");
            });
        }
    }
}