using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.Project.Command.RemoveProject
{
    public class RemoveProjectCommandValidator : AbstractValidator<RemoveProjectCommand>
    {
        public RemoveProjectCommandValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.ProjectId).Custom((value, context) =>
            {
                var project = dbContext.Projects.Any(e => e.Id == value && e.Enabled);
                if (!project)
                    context.AddFailure("Id", "The Project with Id: " + value + " doesn't exist");
            });
        }
    }
}