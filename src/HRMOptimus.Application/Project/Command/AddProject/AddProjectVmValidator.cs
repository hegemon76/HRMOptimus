using FluentValidation;

namespace HRMOptimus.Application.Project.Command.AddProject
{
    public class AddProjectVmValidator : AbstractValidator<AddProjectVm>
    {
        public AddProjectVmValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.DateTo).GreaterThan(x => x.DateFrom).NotEmpty();
            RuleFor(x => x.DateTo).NotEmpty().LessThanOrEqualTo(x => x.Deadline);
            RuleFor(x => x.HoursBudget).NotEmpty().GreaterThan(0);
        }
    }
}