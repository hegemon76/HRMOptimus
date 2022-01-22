using System.Collections.Generic;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface IUserContextService
    {
        string GetUserId { get; }
        int? GetEmployeeId { get; }
        string GetFullName { get; }

        List<string> GetRoles();
    }
}