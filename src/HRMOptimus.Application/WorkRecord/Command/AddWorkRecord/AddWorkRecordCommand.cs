using MediatR;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    public class AddWorkRecordCommand : IRequest<int>
    {
        public AddWorkRecordVm AddWorkRecordVm { get; set; }
    }
}