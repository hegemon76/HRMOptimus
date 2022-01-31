using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    public class AddWorkRecordCommandHandler : IRequestHandler<AddWorkRecordCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;
        private readonly IUserContextService _userContextService;

        public AddWorkRecordCommandHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<int> Handle(AddWorkRecordCommand request, CancellationToken cancellationToken)
        {
            var employeeId = _userContextService.GetEmployeeId.Value;

            var duration = request.AddWorkRecordVm.WorkEnd.TimeOfDay - request.AddWorkRecordVm.WorkStart.TimeOfDay;

            var workRecord = new Domain.Entities.WorkRecord()
            {
                Name = request.AddWorkRecordVm.Name,
                WorkStart = request.AddWorkRecordVm.WorkStart,
                WorkEnd = request.AddWorkRecordVm.WorkEnd,
                Duration = duration,
                IsRemoteWork = request.AddWorkRecordVm.IsRemoteWork,
                ProjectId = request.AddWorkRecordVm.ProjectId,
                EmployeeId = employeeId
            };
            _context.WorkRecords.Add(workRecord);

            await _context.SaveChangesAsync(cancellationToken);
            return workRecord.Id;
        }
    }
}