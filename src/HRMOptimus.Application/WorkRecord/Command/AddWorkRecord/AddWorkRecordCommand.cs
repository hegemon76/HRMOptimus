using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    class AddWorkRecordCommand : IRequest<string>
    {
        public WorkRecordVm WorkRecordVm { get; set; }
    }
}
