using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Project.Command.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, int>
    {
        private readonly IHRMOptimusDbContext _context;

        public AddEmployeeCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee =  _context.Employees.FirstOrDefault(x => x.Id == request.AddEmployeeVm.EmployeeId);

                var project = _context.Projects.Include(x => x.ProjectMembers)
                    .FirstOrDefault(p => p.Id == request.AddEmployeeVm.ProjectId);

                project.ProjectMembers.Add(employee);

                await _context.SaveChangesAsync(cancellationToken);

                return 1;
            }
            catch (Exception)
            {
                return 0;

            }
        }
    }
}
