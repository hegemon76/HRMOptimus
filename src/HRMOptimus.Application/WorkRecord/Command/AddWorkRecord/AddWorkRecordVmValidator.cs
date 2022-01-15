using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System;
using System.Linq;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    public class AddWorkRecordVmValidator : AbstractValidator<AddWorkRecordVm>
    {
        public AddWorkRecordVmValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5);

            RuleFor(x => x.ProjectId).NotEmpty().Custom((value, context) =>
            {
                var project = dbContext.Projects.Any(e => e.Id == value && e.Enabled);
                if (!project)
                    context.AddFailure("Id", "The Project with Id: " + value + " doesn't exist");
            });

            RuleFor(x => x.WorkStart).NotEmpty();
            RuleFor(x => x.WorkEnd).NotEmpty().GreaterThan(x => x.WorkStart);
            RuleFor(x => x.IsRemoteWork).NotEmpty();
        }
    }
}