using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public class DayWorkRecordsQueryHandler : IRequestHandler<DayWorkRecordsQuery, DayWorkRecordsVm>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _context;

        public DayWorkRecordsQueryHandler(IHRMOptimusDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<DayWorkRecordsVm> Handle(DayWorkRecordsQuery request, CancellationToken cancellationToken)
        {
            //var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            //var user = _userManager.FindByIdAsync(userId);

            var workRecords = await _context.WorkRecords
                //.Where(x => x.EmployeeId == user.Result.EmployeeId)
                .Where(x => x.WorkStart.Date == request.DayWork.Date)
                //.Select(x => new WorkRecordVm(x.Name, x.WorkStart, x.WorkEnd, x.Duration
                //))
                .ToListAsync();

            return new DayWorkRecordsVm(workRecords, request.DayWork);
        }
    }
}