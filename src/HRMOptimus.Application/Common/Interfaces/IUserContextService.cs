using System.Collections.Generic;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface IUserContextService
    {
        public string GetUserId { get; }
        public int? GetEmployeeId { get; }
        public List<string> GetRoles();
    }
}