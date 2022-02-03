using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecordsAdmin
{
    public class DayWorkRecordsAdminQueryHandler : IRequestHandler<DayWorkRecordsAdminQuery, List<WorkRecordDetailsVm>>
    {
        private readonly IHRMOptimusDbContext _context;

        public DayWorkRecordsAdminQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkRecordDetailsVm>> Handle(DayWorkRecordsAdminQuery request, CancellationToken cancellationToken)
        {
            var workRecords = await _context.WorkRecords
                .Where(x => x.EmployeeId == request.EmployeeId)
                .Where(x => x.WorkStart.Date == request.DayWork.Date && x.Enabled)
                .Include(x => x.Project)
                .Select(x => new WorkRecordDetailsVm(x.Id, x.Name, x.WorkStart, x.WorkEnd, x.Duration, x.IsRemoteWork, x.Project.Name, x.Project.Id))
                .ToListAsync();

            return workRecords;
        }
    }
}