using HRMOptimus.Domain.Entities;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface ICreateTokenService
    {
        Task<string> CreateToken(string userId);
    }
}