using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface IDecodeTokenService
    {
        string FullName { get; }

        ApplicationUser decodeToken(string token, UserManager<ApplicationUser> userManager);
    }
}