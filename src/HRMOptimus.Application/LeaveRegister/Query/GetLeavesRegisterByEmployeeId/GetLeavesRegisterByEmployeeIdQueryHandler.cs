using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId
{
    class GetLeavesRegisterByEmployeeIdQueryHandler : IRequestHandler<GetLeavesRegisterByEmployeeIdQuery, List<LeavesRegisterListVm>>
    {
        private readonly IHRMOptimusDbContext _context;

        public GetLeavesRegisterByEmployeeIdQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        public async Task<List<LeavesRegisterListVm>> Handle(GetLeavesRegisterByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Employee employee = await _context.Employees.Include(x => x.LeavesRegister)
                    .FirstOrDefaultAsync(u => u.Id == request.EmployeeId);

                if (employee != null && employee.LeavesRegister != null)
                {
                    var leavesList = await _context.LeavesRegister.Where(x => x.EmployeeId == employee.Id).Select(x =>
                         new LeavesRegisterListVm
                         {
                             Id = x.Id,
                             DateFrom = x.DateFrom,
                             DateTo = x.DateTo,
                             Duration = x.Duration,
                             IsApproved = x.IsApproved,
                             IsRejected = x.IsRejected
                         }).ToListAsync();
                    
                    return leavesList;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
