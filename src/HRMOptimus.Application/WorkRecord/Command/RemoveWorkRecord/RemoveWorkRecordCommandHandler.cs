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
        private readonly IUserContextService _userContextService;

        public RemoveWorkRecordCommandHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<Unit> Handle(RemoveWorkRecordCommand request, CancellationToken cancellationToken)
        {
            var workRecord = await _context.WorkRecords.FirstOrDefaultAsync(x => x.Id == request.WorkRecordId);

            var employeeId = _userContextService.GetEmployeeId.Value;

            if (employeeId != workRecord.EmployeeId)
                throw new BadRequestException("This is not allowed operation");

            _context.WorkRecords.Remove(workRecord);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}