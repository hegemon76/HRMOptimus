using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId
{
    internal class GetLeavesRegisterByEmployeeIdQueryHandler : IRequestHandler<GetLeavesRegisterByEmployeeIdQuery, LeavesRegisterVm>
    {
        private readonly IHRMOptimusDbContext _context;

        public GetLeavesRegisterByEmployeeIdQueryHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
        }

        public async Task<LeavesRegisterVm> Handle(GetLeavesRegisterByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _context.Employees.Include(x => x.LeavesRegister)
                    .Include(p => p.Contract)
                    .Where(x => x.Enabled == true)
                    .FirstOrDefaultAsync(u => u.Id == request.EmployeeId);

                if (employee != null && employee.LeavesRegister != null)
                {
                    var leavesRecord = await _context.LeavesRegister.Where(x => x.EmployeeId == employee.Id && x.Enabled == true)
                        .Select(x => new LeaveRecord
                        {
                            Id = x.Id,
                            DateFrom = x.DateFrom,
                            DateTo = x.DateTo,
                            Duration = x.Duration,
                            IsApproved = x.IsApproved,
                            LeaveRegisterType = x.LeaveRegisterType
                        }).ToListAsync();

                    var leaves = new LeavesRegisterVm()
                    {
                        LeaveDaysLeft = (int)employee.LeaveDaysLeft,
                        LeaveDaysByContract = (int)employee.Contract.LeaveDays,
                        LeaveRecords = leavesRecord,
                    };

                    return leaves;
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