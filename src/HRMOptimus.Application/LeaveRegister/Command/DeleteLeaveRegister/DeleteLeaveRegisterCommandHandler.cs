using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Command.DeleteLeaveRegister
{
    class DeleteLeaveRegisterCommandHandler : IRequestHandler<DeleteLeaveRegisterCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;

        public DeleteLeaveRegisterCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteLeaveRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var leaveRegister = _context.LeavesRegister.FirstOrDefault(x => x.Id == request.DeleteLeaveRegisterVm.Id);
                _context.LeavesRegister.Remove(leaveRegister);
                await _context.SaveChangesAsync(cancellationToken);
                return 1;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
    }
}
