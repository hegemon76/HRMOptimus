using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Command.RemoveWorkRecord
{
    public class RemoveWorkRecordCommandHandler : IRequestHandler<RemoveWorkRecordCommand>
    {
        private readonly IHRMOptimusDbContext _context;

        public RemoveWorkRecordCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveWorkRecordCommand request, CancellationToken cancellationToken)
        {
            var workRecord = await _context.WorkRecords.FirstOrDefaultAsync(x => x.Id == request.WorkRecordId);

            if (workRecord == null)
                throw new NotFoundException("There is no work record with Id: " + request.WorkRecordId);

            workRecord.Enabled = false;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}