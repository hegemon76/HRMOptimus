using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public class DayWorkRecordsQueryHandler : IRequestHandler<DayWorkRecordsQuery, List<WorkRecordVm>>
    {
        private readonly IHRMOptimusDbContext _context;
        //private readonly IUserContextService _userContextService;

        public DayWorkRecordsQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
            //_userContextService = userContextService;
        }

        public async Task<List<WorkRecordVm>> Handle(DayWorkRecordsQuery request, CancellationToken cancellationToken)
        {
            //var userId = _userContextService.GetEmployeeId;

            var workRecords = await _context.WorkRecords
                //.Where(x => x.EmployeeId == userId)
                .Where(x => x.WorkStart.Date == request.DayWork.Date && x.Enabled)
                .Select(x => new WorkRecordVm(x.Id, x.Name, x.WorkStart, x.WorkEnd, x.Duration))
                .ToListAsync();

            return workRecords;
        }
    }
}