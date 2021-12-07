using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.WorkRecord.Command.UpdateWorkRecord
{
    public class UpdateWorkRecordVmValidator : AbstractValidator<UpdateWorkRecordVm>
    {
        public UpdateWorkRecordVmValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.Name).MinimumLength(5);

            RuleFor(x => x.Id).Custom((value, context) =>
            {
                var workRecord = dbContext.WorkRecords.Any(e => e.Id == value && e.Enabled);
                if (!workRecord)
                    context.AddFailure("Id", "The Work Record with Id: " + value + " doesn't exist");
            });

            RuleFor(x => x.ProjectId).Custom((value, context) =>
            {
                var project = dbContext.Projects.Any(e => e.Id == value && e.Enabled);
                if (!project)
                    context.AddFailure("Id", "The Project with Id: " + value + " doesn't exist");
            });

            RuleFor(x => x.WorkStart).NotEmpty();
            RuleFor(x => x.WorkEnd).NotEmpty();
            RuleFor(x => x.WorkEnd).GreaterThan(x => x.WorkStart);
        }
    }
}