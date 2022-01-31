using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using System.Linq;

namespace HRMOptimus.Application.WorkRecord.Command.RemoveWorkRecord
{
    public class RemoveWorkRecordCommandValidator : AbstractValidator<RemoveWorkRecordCommand>
    {
        public RemoveWorkRecordCommandValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.WorkRecordId).NotEmpty().Custom((value, context) =>
            {
                var workRecord = dbContext.WorkRecords.Any(e => e.Id == value && e.Enabled);
                if (!workRecord)
                    context.AddFailure("Id", "The WorkRecord with Id: " + value + " doesn't exist");
            });
        }
    }
}