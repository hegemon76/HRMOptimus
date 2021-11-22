using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    internal class AddWorkRecordCommandHandler : IRequestHandler<AddWorkRecordCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;

        public AddWorkRecordCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddWorkRecordCommand request, CancellationToken cancellationToken)
        {
            var duration = request.AddWorkRecordVm.WorkEnd.TimeOfDay - request.AddWorkRecordVm.WorkStart.TimeOfDay;

            var workRecord = new Domain.Entities.WorkRecord()
            {
                Name = request.AddWorkRecordVm.Name,
                WorkStart = request.AddWorkRecordVm.WorkStart,
                WorkEnd = request.AddWorkRecordVm.WorkEnd,
                Duration = duration,
                ProjectId = request.AddWorkRecordVm.ProjectId,
                EmployeeId = request.AddWorkRecordVm.EmployeeId
            };
            _context.WorkRecords.Add(workRecord);

            await _context.SaveChangesAsync(cancellationToken);
            return workRecord.Id;
        }
    }
}