using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecordsAdmin
{
    public class MonthDaysRecordsAdminQueryHandler : IRequestHandler<MonthDaysRecordsAdminQuery, MonthWorkRecordsVm>
    {
        private readonly IHRMOptimusDbContext _context;

        public MonthDaysRecordsAdminQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<MonthWorkRecordsVm> Handle(MonthDaysRecordsAdminQuery request, CancellationToken cancellationToken)
        {
            var employeeId = request.EmployeeId;
            List<DaysWorkRecordsVm> daysWorksRekords = new List<DaysWorkRecordsVm>();
            DateTime firstDay;
            TimeSpan workedTimeFromAllDays = default;

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

            var daysInMonth = DateTime.DaysInMonth(firstDay.Year, firstDay.Month);
            var lastDay = new DateTime(firstDay.Year, firstDay.Month, daysInMonth);

            var workRecords = await _context.WorkRecords
                .Where(x => (x.WorkStart.Date >= firstDay || x.WorkStart.Date <= lastDay)
                 && x.EmployeeId == employeeId && x.Enabled)
                .Select(x => new WorkRecordVm(x.Id, x.WorkStart, x.WorkEnd, x.Duration))
                .ToListAsync();

            for (int i = 1; i <= daysInMonth; i++)
            {
                TimeSpan workedTime = default;
                TimeSpan startHour = default;
                TimeSpan endHour = default;
                var day = new DateTime(firstDay.Year, firstDay.Month, i);
                var rekordsOfDay = workRecords.Where(x => x.WorkStart.Date == day);

                foreach (var record in rekordsOfDay)
                {
                    startHour = startHour > record.WorkStart.TimeOfDay || startHour == default ? record.WorkStart.TimeOfDay : startHour;
                    endHour = endHour < record.WorkStop.TimeOfDay || startHour == default ? record.WorkStop.TimeOfDay : endHour;
                    workedTime += record.Duration;
                }
                workedTimeFromAllDays += workedTime;

                daysWorksRekords.Add(new DaysWorkRecordsVm(startHour, endHour, day, workedTime));
            }

            return new MonthWorkRecordsVm(workedTimeFromAllDays.ToString(), daysWorksRekords);
        }
    }
}