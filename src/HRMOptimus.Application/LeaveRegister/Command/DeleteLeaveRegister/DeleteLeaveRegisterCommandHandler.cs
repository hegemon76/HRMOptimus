using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HRMOptimus.Domain.Enums;
using System;

namespace HRMOptimus.Application.LeaveRegister.Command.DeleteLeaveRegister
{
    class DeleteLeaveRegisterCommandHandler : IRequestHandler<DeleteLeaveRegisterCommand>
    {
        private readonly IHRMOptimusDbContext _context;
        private readonly IUserContextService _userContextService;

        public DeleteLeaveRegisterCommandHandler(IHRMOptimusDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }
        public async Task<Unit> Handle(DeleteLeaveRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var leaveRegister = _context.LeavesRegister.FirstOrDefault(x => x.Id == request.Id);
                int employeeId = _userContextService.GetEmployeeId.Value;

                if (employeeId == 0)
                    employeeId = (int)request.EmployeeId;
                var employee = _context.Employees.FirstOrDefault(x => x.Id == employeeId);

                if (leaveRegister.IsApproved == IsApproved.Approved)
                    employee.LeaveDaysLeft += leaveRegister.Duration;

                leaveRegister.Enabled = false;

                _context.Employees.Update(employee);
                _context.LeavesRegister.Update(leaveRegister);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (Exception)
            {
                return Unit.Value;
            }
        }

        //Task<Unit> IRequestHandler<DeleteLeaveRegisterCommand, Unit>.Handle(DeleteLeaveRegisterCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
