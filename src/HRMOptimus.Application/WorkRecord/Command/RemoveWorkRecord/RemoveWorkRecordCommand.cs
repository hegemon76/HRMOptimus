using MediatR;

namespace HRMOptimus.Application.WorkRecord.Command.RemoveWorkRecord
{
    public class RemoveWorkRecordCommand : IRequest
    {
        public int WorkRecordId { get; set; }
    }
}