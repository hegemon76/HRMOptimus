﻿using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public class DayWorkRecordsQueryHandler : IRequestHandler<DayWorkRecordsQuery, List<WorkRecordDetailsVm>>
    {
        private readonly IHRMOptimusDbContext _context;
        private readonly IUserContextService _userContextService;

        public DayWorkRecordsQueryHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<List<WorkRecordDetailsVm>> Handle(DayWorkRecordsQuery request, CancellationToken cancellationToken)
        {
            var employeeId = _userContextService.GetEmployeeId.Value;

            var workRecords = await _context.WorkRecords
                .Where(x => x.EmployeeId == employeeId)
                .Where(x => x.WorkStart.Date == request.DayWork.Date && x.Enabled)
                .Include(x => x.Project)
                .Select(x => new WorkRecordDetailsVm(x.Id, x.Name, x.WorkStart, x.WorkEnd, x.Duration, x.IsRemoteWork, x.Project.Name, x.Project.Id))
                .ToListAsync();

            return workRecords;
        }
    }
}