using HRMOptimus.Application.Common.Exceptions;
using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails
{
    public class WorkRecordDetailsQueryHandler : IRequestHandler<WorkRecordDetailsQuery, WorkRecordDetailsVm>
    {
        private readonly IHRMOptimusDbContext _context;

        public WorkRecordDetailsQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<WorkRecordDetailsVm> Handle(WorkRecordDetailsQuery request, CancellationToken cancellationToken)
        {
            var workRecord = await _context.WorkRecords
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .FirstOrDefaultAsync(x => x.Id == request.WorkRecordId && x.Enabled);

            if (workRecord == null)
                throw new NotFoundException("There is no work record with Id: " + request.WorkRecordId);

            return new WorkRecordDetailsVm(workRecord.Name, workRecord.WorkStart, workRecord.WorkEnd,
                workRecord.Duration, workRecord.Project.Name, workRecord.Employee.FullName);
        }
    }
}