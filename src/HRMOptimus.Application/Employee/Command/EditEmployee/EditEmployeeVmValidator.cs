using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
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

            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.BuildingNumber).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.HouseNumber).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();

            RuleFor(x => x.ZipCode).NotEmpty()
                .Matches("[0-9]{2}-[0-9]{3}").WithMessage("'{PropertyName}' must match pattern 00-000");
        }
    }
}