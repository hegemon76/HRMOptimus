using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HRMOptimus.Domain.Enums;
using System;

namespace HRMOptimus.Application.LeaveRegister.Command.DeleteLeaveRegister
{
    class DeleteLeaveRegisterCommandHandler : IRequestHandler<DeleteLeaveRegisterCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;
        private readonly IUserContextService _userContextService;

        public DeleteLeaveRegisterCommandHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }
        public async Task<int> Handle(DeleteLeaveRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var leaveRegister = _context.LeavesRegister.FirstOrDefault(x => x.Id == request.DeleteLeaveRegisterVm.Id);
                int employeeId = _userContextService.GetEmployeeId.Value;

                if (employeeId == 0)
                    employeeId = (int)request.DeleteLeaveRegisterVm.EmployeeId;
                var employee = _context.Employees.FirstOrDefault(x => x.Id == employeeId);

                if (leaveRegister.IsApproved == IsApproved.Approved)
                    employee.LeaveDaysLeft += leaveRegister.Duration;

                leaveRegister.Enabled = false;

                _context.Employees.Update(employee);
                _context.LeavesRegister.Update(leaveRegister);
                await _context.SaveChangesAsync(cancellationToken);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
