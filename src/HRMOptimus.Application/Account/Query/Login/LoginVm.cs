using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Application.Account.Query.Login
{
    public record LoginVm(string firstName, string lastName, Genre genre ,string id, string employeeId);
}
