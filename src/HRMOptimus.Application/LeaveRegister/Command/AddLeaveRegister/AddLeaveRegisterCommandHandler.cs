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

namespace HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister
{
    class AddLeaveRegisterCommandHandler : IRequestHandler<AddLeaveRegisterCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;

        public AddLeaveRegisterCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddLeaveRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var duration = request.AddLeaveRegisterVm.WorkEnd - request.AddLeaveRegisterVm.WorkStart;

                Employee user = await _context.Employees.Include(leaves => leaves.LeavesRegister)
                    .FirstOrDefaultAsync(x => x.Id == request.AddLeaveRegisterVm.EmployeeId);
                if (user != null)
                {
                    Domain.Entities.LeaveRegister leaveRegister = new Domain.Entities.LeaveRegister()
                    {
                        Duration = duration.Days,
                        DateFrom = request.AddLeaveRegisterVm.WorkStart,
                        DateTo = request.AddLeaveRegisterVm.WorkEnd,
                        EmployeeId = request.AddLeaveRegisterVm.EmployeeId,
                        Employee = user,
                        IsApproved = false,
                        IsRejected = false
                    };

                    user.LeaveDaysLeft -= duration.Days;
                    user.LeavesRegister.Add(leaveRegister);
                    _context.LeavesRegister.Add(leaveRegister);

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
