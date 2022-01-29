using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Enums;
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
        private readonly IUserContextService _userContextService;

        public MonthDaysRecordsQueryHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<List<DaysWorkRecordsVm>> Handle(MonthDaysRecordsQuery request, CancellationToken cancellationToken)
        {
            var employeeId = _userContextService.GetEmployeeId.Value;
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

            if (request.EmployeeId.HasValue)
            {
                var roles = _userContextService.GetRoles();
                foreach (var role in roles)
                {
                    if (role == nameof(UserRoles.Administrator))
                    {
                        employeeId = request.EmployeeId.Value;
                    }
                }
            }

            var daysInMonth = DateTime.DaysInMonth(firstDay.Year, firstDay.Month);
            var lastDay = new DateTime(firstDay.Year, firstDay.Month, daysInMonth);

            var workRecords = await _context.WorkRecords
                .Where(x => (x.WorkStart.Date >= firstDay || x.WorkStart.Date <= lastDay)
                 && x.EmployeeId == employeeId
                 && x.Enabled)
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

                daysWorksRekords.Add(new DaysWorkRecordsVm(startHour, endHour, day, workedTime, workedTimeFromAllDays));
            }

            return daysWorksRekords;
        }
    }
}