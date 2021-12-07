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
                var employee = _context.Employees.FirstOrDefault(x => x.Id == _userContextService.GetEmployeeId);

                if (leaveRegister.IsApproved == IsApproved.Approved)
                {
                    employee.LeaveDaysLeft += leaveRegister.Duration;
                }

                _context.Employees.Update(employee);
                _context.LeavesRegister.Remove(leaveRegister);
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
