using MediatR;

namespace HRMOptimus.Application.WorkRecord.Command.UpdateWorkRecord
{
    public class UpdateWorkRecordCommand : IRequest
    {
        public UpdateWorkRecordVm UpdateWorkRecordVm { get; set; }
    }
}