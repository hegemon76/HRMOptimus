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
            List<DaysWorkRecordsVm> daysWorksRekords = new List<DaysWorkRecordsVm>();
            DateTime firstDay;

            if (request.MonthFromCurrent.HasValue)
            {
                firstDay = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1).AddMonths(request.MonthFromCurrent.Value);
            }
            else if (request.Month.HasValue && request.Year.HasValue)
            {
                firstDay = new DateTime(request.Year.Value, request.Month.Value, 1);
            }
            else
            {
                firstDay = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            }

            var days = DateTime.DaysInMonth(firstDay.Year, firstDay.Month);
            var lastDay = new DateTime(firstDay.Year, firstDay.Month, days);

            var workRecords = await _context.WorkRecords
                .Where(x => (x.WorkStart.Date >= firstDay || x.WorkStart.Date <= lastDay) && x.Enabled)
                .Select(x => new WorkRecordVm(x.Id, x.WorkStart, x.WorkEnd, x.Duration))
                .ToListAsync();

            for (int i = 1; i <= days; i++)
            {
                TimeSpan workedTime = default;
                TimeSpan startHour = default;
                TimeSpan endHour = default;
                var day = new DateTime(firstDay.Year, firstDay.Month, i);
                var rekordsOfDay = workRecords.Where(x => x.WorkStart.Date == day).ToList();

                foreach (var record in rekordsOfDay)
                {
                    startHour = startHour > record.WorkStart.TimeOfDay || startHour == default ? record.WorkStart.TimeOfDay : startHour;
                    endHour = endHour < record.WorkStop.TimeOfDay || startHour == default ? record.WorkStop.TimeOfDay : endHour;
                    workedTime += record.Duration;
                }
                daysWorksRekords.Add(new DaysWorkRecordsVm(startHour, endHour, day, workedTime));
            }

            return daysWorksRekords;
        }
    }
}