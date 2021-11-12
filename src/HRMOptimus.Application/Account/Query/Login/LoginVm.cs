using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Application.Account.Query.Login
{
    public record LoginVm(string firstName, string lastName, Gender gender ,string id, string employeeId);
}
