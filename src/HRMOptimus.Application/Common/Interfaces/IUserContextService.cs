using System.Collections.Generic;
using System.Security.Claims;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface IUserContextService
    {
        public string GetUserId { get; }
        public int? GetEmployeeId { get; }
        public List<ClaimsPrincipal> Roles { get; }
    }
}