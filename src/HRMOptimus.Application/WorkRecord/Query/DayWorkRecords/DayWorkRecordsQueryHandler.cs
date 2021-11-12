using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public class DayWorkRecordsQueryHandler : IRequestHandler<DayWorkRecordsQuery, DayWorkRecordsVm>
    {
        public IHRMOptimusDbContext _context { get; }

        public DayWorkRecordsQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<DayWorkRecordsVm> Handle(DayWorkRecordsQuery request, CancellationToken cancellationToken)
        {
            var workRecords = await _context.WorkRecords
                .Where(x => x.WorkStart.Date == request.DayWork.Date)
               // .Include(x=>x.Project.Name)
               // //.Include(x => x.Project)
               // //.ThenInclude(x=>x.Name)
               //.Include(x=>x.Employee.FullName)
                .ToListAsync();

            return new DayWorkRecordsVm(workRecords, request.DayWork);
        }
    }
}
