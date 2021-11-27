using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails;
using HRMOptimus.Domain.Entities;
using MediatR;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserContextService _userContextService;

        public MonthDaysRecordsQueryHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<List<DaysWorkRecordsVm>> Handle(MonthDaysRecordsQuery request, CancellationToken cancellationToken)
        {
            var workRecords = await _context.WorkRecords
                .Where(x => x.WorkStart.Date >= request.DateFrom.Date || x.WorkStart.Date <= request.DateTo.Date && x.Enabled)
                .Select(x => new WorkRecordVm(x.Name, x.WorkStart, x.WorkEnd, x.Duration))
                .ToListAsync();

            List<DaysWorkRecordsVm> daysWorksRekords = new List<DaysWorkRecordsVm>();
            var dayWorkRecords = new List<WorkRecordVm>();

            TimeSpan workedTime = default;
            for (int i = 0; i < workRecords.Count; i++)
            {
                if (i == 0)
                {
                    dayWorkRecords.Add(workRecords[i]);
                    workedTime = workRecords[i].Duration;
                }
                else if (workRecords[i].WorkStart.Date == workRecords[i - 1].WorkStart.Date)
                {
                    dayWorkRecords.Add(workRecords[i]);
                    workedTime += workRecords[i].Duration;
                }
                else
                {
                    daysWorksRekords.Add(new DaysWorkRecordsVm(dayWorkRecords, workRecords[i].WorkStart.Date, workedTime));

                    dayWorkRecords = new List<WorkRecordVm>();

                    dayWorkRecords.Add(workRecords[i]);
                    workedTime = workRecords[i].Duration;
                }
            }

            return daysWorksRekords;
        }
    }
}