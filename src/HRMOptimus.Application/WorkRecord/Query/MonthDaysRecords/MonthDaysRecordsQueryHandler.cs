using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public class MonthDaysRecordsQueryHandler : IRequestHandler<MonthDaysRecordsQuery, List<DaysWorkRecordsVm>>
    {
        private readonly IHRMOptimusDbContext _context;
        // private readonly IUserContextService _userContextService;

        public MonthDaysRecordsQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
            // _userContextService = userContextService;
        }

        public async Task<List<DaysWorkRecordsVm>> Handle(MonthDaysRecordsQuery request, CancellationToken cancellationToken)
        {
            TimeSpan workedTime = default;
            var days = DateTime.DaysInMonth(request.DateFrom.Year, request.DateTo.Month);
            var day = request.DateFrom;
            List<DaysWorkRecordsVm> daysWorksRekords = new List<DaysWorkRecordsVm>();
            //var dayWorkRecords = new List<WorkRecordVm>();

            var workRecords = await _context.WorkRecords
                .Where(x => (x.WorkStart.Date >= request.DateFrom.Date || x.WorkStart.Date <= request.DateTo.Date) && x.Enabled)
                .Select(x => new WorkRecordVm(x.Id, x.WorkStart, x.WorkEnd, x.Duration))
                .ToListAsync();

            for (int i = 1; i <= days; i++)
            {
                var rekordsOfDay = workRecords.Where(x => x.WorkStart.Date == day).ToList();
                foreach (var record in rekordsOfDay)
                {
                    workedTime += record.Duration;
                }
                daysWorksRekords.Add(new DaysWorkRecordsVm(rekordsOfDay, day, workedTime));
                day = day.AddDays(1);
            }
            //for (int i = 0; i < workRecords.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        dayWorkRecords.Add(workRecords[i]);
            //        workedTime = workRecords[i].Duration;
            //    }
            //    else if (workRecords[i].WorkStart.Date == workRecords[i - 1].WorkStart.Date)
            //    {
            //        dayWorkRecords.Add(workRecords[i]);
            //        workedTime += workRecords[i].Duration;
            //        if (i == workRecords.Count - 1)
            //            daysWorksRekords.Add(new DaysWorkRecordsVm(dayWorkRecords, workRecords[i].WorkStart.Date, workedTime));
            //    }
            //    else
            //    {
            //        daysWorksRekords.Add(new DaysWorkRecordsVm(dayWorkRecords, workRecords[i].WorkStart.Date, workedTime));

            //        dayWorkRecords = new List<WorkRecordVm>();

            //        dayWorkRecords.Add(workRecords[i]);
            //        workedTime = workRecords[i].Duration;
            //    }
            // }

            return daysWorksRekords;
        }
    }
}