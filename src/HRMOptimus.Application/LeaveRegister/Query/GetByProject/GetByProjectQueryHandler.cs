using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Query.GetByProject
{
    public class GetByProjectQueryHandler : IRequestHandler<GetByProjectQuery, List<GetByProjectVm>>
    {
        private readonly IHRMOptimusDbContext _context;

        public GetByProjectQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetByProjectVm>> Handle(GetByProjectQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var project = await _context.Projects.Include(x => x.ProjectMembers)
                    .FirstOrDefaultAsync(x => x.Id == request.ProjectId);

                if (project == null)
                    return null;
                

                foreach (var item in project.ProjectMembers)
                {

                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
