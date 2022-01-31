using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister
{
    internal class AddLeaveRegisterCommandHandler : IRequestHandler<AddLeaveRegisterCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;

        public AddLeaveRegisterCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddLeaveRegisterCommand request, CancellationToken cancellationToken)
        {
            var daysList = Enumerable.Range(0, 1 + request.AddLeaveRegisterVm.LeaveEnd.Date
                .Subtract(request.AddLeaveRegisterVm.LeaveStart.Date).Days)
                .Select(offset => request.AddLeaveRegisterVm.LeaveStart.Date.AddDays(offset))
                .ToList();

            int duration = 0;

            foreach (var item in daysList)
            {
                if (item.DayOfWeek != DayOfWeek.Saturday && item.DayOfWeek != DayOfWeek.Sunday)
                    duration++;
            }
            var employee = await _context.Employees.Include(leaves => leaves.LeavesRegister)
                .FirstOrDefaultAsync(x => x.Id == request.AddLeaveRegisterVm.EmployeeId);

            if (employee != null)
            {
                Domain.Entities.LeaveRegister leaveRegister = new Domain.Entities.LeaveRegister()
                {
                    Duration = duration,
                    DateFrom = request.AddLeaveRegisterVm.LeaveStart.Date,
                    DateTo = request.AddLeaveRegisterVm.LeaveEnd.Date,
                    EmployeeId = request.AddLeaveRegisterVm.EmployeeId,
                    Employee = employee,
                    IsApproved = IsApproved.UnChecked,
                    LeaveRegisterType = request.AddLeaveRegisterVm.LeaveRegisterType
                };

                employee.LeavesRegister.Add(leaveRegister);
                _context.LeavesRegister.Add(leaveRegister);

                _context.Employees.Update(employee);

                await _context.SaveChangesAsync(cancellationToken);
                return leaveRegister.Id;
            }
            return 0;
        }
    }
}