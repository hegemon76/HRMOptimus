using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Command.UpdateWorkRecord
{
    public class UpdateWorkRecordCommandHandler : IRequestHandler<UpdateWorkRecordCommand>
    {
        private readonly IHRMOptimusDbContext _context;

        public UpdateWorkRecordCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateWorkRecordCommand request, CancellationToken cancellationToken)
        {
            var workRecord = await _context.WorkRecords.FindAsync(request.UpdateWorkRecordVm.Id);

            var duration = request.UpdateWorkRecordVm.WorkEnd.TimeOfDay - request.UpdateWorkRecordVm.WorkStart.TimeOfDay;

            workRecord.Name = request.UpdateWorkRecordVm.Name;
            workRecord.WorkStart = request.UpdateWorkRecordVm.WorkStart;
            workRecord.WorkEnd = request.UpdateWorkRecordVm.WorkEnd;
            workRecord.Duration = duration;
            workRecord.ProjectId = request.UpdateWorkRecordVm.ProjectId;
            workRecord.EmployeeId = request.UpdateWorkRecordVm.EmployeeId;

            _context.WorkRecords.Update(workRecord);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}