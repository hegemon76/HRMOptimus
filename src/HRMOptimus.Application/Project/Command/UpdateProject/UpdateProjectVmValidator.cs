using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.Project.Command.UpdateProject
{
    public class UpdateProjectVmValidator : AbstractValidator<UpdateProjectVm>
    {
        public UpdateProjectVmValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .Custom((value, context) =>
                {
                    var project = dbContext.Projects.Any(e => e.Id == value && e.Enabled);
                    if (!project)
                        context.AddFailure("Id", "The Project with Id: " + value + " doesn't exist");
                });
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.DateTo).GreaterThan(x => x.DateFrom).NotEmpty();
            RuleFor(x => x.DateTo).NotEmpty().LessThanOrEqualTo(x => x.Deadline);
            RuleFor(x => x.HoursBudget).NotEmpty().GreaterThan(0);
        }
    }
}