using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister
{
    public class ChangeStatusLeaveRegisterCommandHandler : IRequestHandler<ChangeStatusLeaveRegisterCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;

        public ChangeStatusLeaveRegisterCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(ChangeStatusLeaveRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Employees.Include(x => x.LeavesRegister)
                    .FirstOrDefaultAsync(x => x.Id == request.ChangeStatusLeaveRegisterVm.EmployeeId);

                var leaveRegister = await _context.LeavesRegister.FirstOrDefaultAsync(x => x.Id == request.ChangeStatusLeaveRegisterVm.RecordId);

                if (user != null && leaveRegister != null)
                {
                    if (request.ChangeStatusLeaveRegisterVm.Status == leaveRegister.IsApproved)
                        return 0;

                    if (request.ChangeStatusLeaveRegisterVm.Status != IsApproved.Approved && leaveRegister.IsApproved == IsApproved.Approved)
                    {
                        user.LeaveDaysLeft += leaveRegister.Duration;
                    }
                    else if (request.ChangeStatusLeaveRegisterVm.Status == IsApproved.Approved && leaveRegister.IsApproved != IsApproved.Approved)
                    {
                        user.LeaveDaysLeft -= leaveRegister.Duration;
                    }

                    leaveRegister.IsApproved = request.ChangeStatusLeaveRegisterVm.Status;
                    await _context.SaveChangesAsync(cancellationToken);
                    return leaveRegister.Id;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
