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
            var day = request.DateFrom;
            var days = DateTime.DaysInMonth(request.DateFrom.Year, request.DateFrom.Month);

            List<DaysWorkRecordsVm> daysWorksRekords = new List<DaysWorkRecordsVm>();

            var workRecords = await _context.WorkRecords
                .Where(x => (x.WorkStart.Date >= request.DateFrom.Date || x.WorkStart.Date <= request.DateTo.Date) && x.Enabled)
                .Select(x => new WorkRecordVm(x.Id, x.WorkStart, x.WorkEnd, x.Duration))
                .ToListAsync();

            for (int i = 1; i <= days; i++)
            {
                TimeSpan workedTime = default;
                TimeSpan startHour = default;
                TimeSpan endHour = default;
                var rekordsOfDay = workRecords.Where(x => x.WorkStart.Date == day).ToList();

                foreach (var record in rekordsOfDay)
                {
                    startHour = startHour > record.WorkStart.TimeOfDay || startHour == default ? record.WorkStart.TimeOfDay : startHour;
                    endHour = endHour < record.WorkStop.TimeOfDay || startHour == default ? record.WorkStop.TimeOfDay : endHour;
                    workedTime += record.Duration;
                }
                daysWorksRekords.Add(new DaysWorkRecordsVm(startHour, endHour, day, workedTime));
                day = day.AddDays(1);
            }

            return daysWorksRekords;
        }
    }
}