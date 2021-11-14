using MediatR;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    public class AddWorkRecordCommand : IRequest<int>
    {
        public WorkRecordVm WorkRecordVm { get; set; }
    }
}
