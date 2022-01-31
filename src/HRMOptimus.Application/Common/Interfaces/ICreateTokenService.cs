using HRMOptimus.Domain.Entities;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface ICreateTokenService
    {
        string CreateToken(string userId);
    }
}