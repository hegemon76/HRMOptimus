using FluentValidation;

namespace HRMOptimus.Application.Project.Command.AddProject
{
    public class AddProjectVmValidator : AbstractValidator<AddProjectVm>
    {
        public AddProjectVmValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.DateFrom).NotEmpty();
            RuleFor(x => x.DateTo).NotEmpty();
            RuleFor(x => x.HoursBudget).GreaterThan(0);
        }
    }
}