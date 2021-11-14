using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    class AddWorkRecordCommandHandler : IRequestHandler<AddWorkRecordCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;

        public AddWorkRecordCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddWorkRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var duration = request.WorkRecordVm.WorkEnd.TimeOfDay - request.WorkRecordVm.WorkStart.TimeOfDay;
                var employee = await _context.Employees.FindAsync(request.WorkRecordVm.EmployeeId);

                var workRecord = new Domain.Entities.WorkRecord()
                {
                    Name = request.WorkRecordVm.Name,
                    WorkStart = request.WorkRecordVm.WorkStart,
                    WorkEnd = request.WorkRecordVm.WorkEnd,
                    Duration = duration,
                    ProjectId = request.WorkRecordVm.ProjectId,
                    EmployeeId = request.WorkRecordVm.EmployeeId
                };
                _context.WorkRecords.Add(workRecord);

                await _context.SaveChangesAsync(cancellationToken);
                return workRecord.Id;
            }
            catch
            {
                return 0;
            }
        }
    }
}
