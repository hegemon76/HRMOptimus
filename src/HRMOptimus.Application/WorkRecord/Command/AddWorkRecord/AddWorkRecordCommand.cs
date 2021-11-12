using MediatR;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    public class AddWorkRecordCommand : IRequest<string>
    {
        public WorkRecordVm WorkRecordVm { get; set; }
    }
}
