using MediatR;
using System.Collections.Generic;

namespace HRMOptimus.Application.LeaveRegister.Query.GetByProject
{
    public class GetByProjectQuery : IRequest<List<GetByProjectVm>>
    {
        public int ProjectId { get; set; }
    }
}