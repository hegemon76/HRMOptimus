using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails
{
    public class WorkRecordDetailsQueryHandler : IRequestHandler<WorkRecordDetailsQuery, WorkRecordDetailsVm>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _context;

        public WorkRecordDetailsQueryHandler(IHRMOptimusDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<WorkRecordDetailsVm> Handle(WorkRecordDetailsQuery request, CancellationToken cancellationToken)
        {
            //var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            //var user = _userManager.FindByIdAsync(userId);

            var workRecord = await _context.WorkRecords
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .FirstOrDefaultAsync(x => x.Id == request.WorkRecordId);

            return new WorkRecordDetailsVm(workRecord.Name, workRecord.WorkStart, workRecord.WorkEnd,
                workRecord.Duration, workRecord.Project.Name, workRecord.Employee.FullName);
        }
    }
}