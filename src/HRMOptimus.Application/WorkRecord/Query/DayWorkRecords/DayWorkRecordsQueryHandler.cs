using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Enums;
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
            var employeeId = _userContextService.GetEmployeeId;

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

            var workRecords = await _context.WorkRecords
                .Where(x => x.EmployeeId == employeeId.Value)
                .Where(x => x.WorkStart.Date == request.DayWork.Date && x.Enabled)
                .Include(x => x.Project)
                .Select(x => new WorkRecordDetailsVm(x.Id, x.Name, x.WorkStart, x.WorkEnd, x.Duration, x.IsRemoteWork, x.Project.Name, x.Project.Id))
                .ToListAsync();

            return workRecords;
        }
    }
}