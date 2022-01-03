using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister
{
    public class ChangeStatusLeaveRegisterCommandHandler : IRequestHandler<ChangeStatusLeaveRegisterCommand, Unit>
    {
        private readonly IHRMOptimusDbContext _context;

        public ChangeStatusLeaveRegisterCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeStatusLeaveRegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Employees.Include(x => x.LeavesRegister)
                .FirstOrDefaultAsync(x => x.Id == request.ChangeStatusLeaveRegisterVm.EmployeeId);

            var leaveRegister = await _context.LeavesRegister.FirstOrDefaultAsync(x => x.Id == request.ChangeStatusLeaveRegisterVm.RecordId);

            if (request.ChangeStatusLeaveRegisterVm.Status != leaveRegister.IsApproved)
            {
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
            }

            return Unit.Value;
        }
    }
}