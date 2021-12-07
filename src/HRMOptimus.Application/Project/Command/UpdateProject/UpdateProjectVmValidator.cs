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
                    var project = dbContext.Projects.Any(e => e.Id == value);
                    if (!project)
                        context.AddFailure("Id", "The Project with Id: " + value + " doesn't exist");
                });
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DateFrom).NotEmpty();
            RuleFor(x => x.DateTo).NotEmpty();
            RuleFor(x => x.Deadline).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.HoursBudget).NotEmpty();
        }
    }
}