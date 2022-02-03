using FluentValidation;
using HRMOptimus.Application.Common.Exceptions;
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
                    throw new NotFoundException("The WorkRecord not found");
            });
        }
    }
}