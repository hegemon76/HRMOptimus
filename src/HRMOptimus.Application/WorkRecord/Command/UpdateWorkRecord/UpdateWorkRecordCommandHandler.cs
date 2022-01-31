using HRMOptimus.Application.Common.Exceptions;
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
        private readonly IUserContextService _userContextService;

        public UpdateWorkRecordCommandHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<Unit> Handle(UpdateWorkRecordCommand request, CancellationToken cancellationToken)
        {
            var workRecord = await _context.WorkRecords.FindAsync(request.UpdateWorkRecordVm.Id);

            var employeeId = _userContextService.GetEmployeeId.Value;

            if (employeeId != workRecord.EmployeeId)
                throw new BadRequestException("This is not allowed operation");

            var duration = request.UpdateWorkRecordVm.WorkEnd.TimeOfDay - request.UpdateWorkRecordVm.WorkStart.TimeOfDay;

            workRecord.Name = request.UpdateWorkRecordVm.Name;
            workRecord.WorkStart = request.UpdateWorkRecordVm.WorkStart;
            workRecord.WorkEnd = request.UpdateWorkRecordVm.WorkEnd;
            workRecord.Duration = duration;
            workRecord.IsRemoteWork = request.UpdateWorkRecordVm.IsRemoteWork;
            workRecord.ProjectId = request.UpdateWorkRecordVm.ProjectId;

            _context.WorkRecords.Update(workRecord);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}