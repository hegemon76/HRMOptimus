using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Models;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Query.Employees
{
    public class EmployeesQueryHandler : IRequestHandler<EmployeesQuery, PageResult<EmployeeVm>>
    {
        private readonly IHRMOptimusDbContext _context;

        public EmployeesQueryHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public async Task<PageResult<EmployeeVm>> Handle(EmployeesQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _context
                .Employees
                .Where(r => r.Enabled)
                .Include(x => x.ApplicationUser)
                .Include(x => x.Contract)
                .Where(r => request.Query.SearchPhrase == null
                    || (r.FullName.ToLower().Contains(request.Query.SearchPhrase.ToLower())
                    || r.ApplicationUser.Email.ToLower().Contains(request.Query.SearchPhrase.ToLower())));

            if (!string.IsNullOrEmpty(request.Query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Domain.Entities.Employee, object>>>
                {
                    { nameof(Domain.Entities.Employee.FullName), r => r.FullName },
                };

                var selectedColumn = columnsSelectors[request.Query.SortBy];

                baseQuery = request.Query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var employees = await baseQuery
                .Skip(request.Query.PageSize * (request.Query.PageNumber - 1))
                .Take(request.Query.PageSize)
                .Select(x => new EmployeeVm(x.Id, x.FirstName, x.LastName, x.FullName,
                x.Gender, x.BirthDate, x.ApplicationUser.Email, x.ApplicationUser.PhoneNumber, x.Contract.ContractName))
                .ToListAsync();

            var totalItemsCount = employees.Count();

            var result = new PageResult<EmployeeVm>(employees, totalItemsCount, request.Query.PageSize, request.Query.PageNumber);

            return result;
        }
    }
}