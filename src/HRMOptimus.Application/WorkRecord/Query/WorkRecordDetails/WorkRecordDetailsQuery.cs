using MediatR;

namespace HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails
{
    public class WorkRecordDetailsQuery : IRequest<WorkRecordDetailsVm>
    {
        public int WorkRecordId { get; set; }
    }
}
