using System.Security.Claims;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        string GetEmployeeName { get; }
        int? GetEmployeeId { get; }
    }
}