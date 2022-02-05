using FluentValidation;
using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.Project.Query.ProjectDetails
{
    public class ProjectDetailsQueryValidator : AbstractValidator<ProjectDetailsQuery>
    {
        public ProjectDetailsQueryValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.ProjectId)
                .Custom((value, context) =>
                {
                    var project = dbContext.Projects.Any(e => e.Id == value && e.Enabled);

                    if (!project)
                        context.AddFailure("WorkRecordId", "Record not found");
                });
        }
    }
}