using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace HRMOptimus.Application.Common.Services
{
    public class DecodeTokenService : IDecodeTokenService
    {
        public string FullName { get; private set; }

        public ApplicationUser decodeToken(string token, UserManager<ApplicationUser> userManager)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var decodedTokenDictionary = new Dictionary<string, object>();
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);

                FullName = jsonToken.Payload.First(claim => claim.Key == "fullName").Value.ToString();
                var userId = jsonToken.Payload.First(claim => claim.Key == "userId").Value.ToString();

                if (userId != null)
                {
                    return userManager.FindByIdAsync(userId).Result;
                }
            }
            return null;
        }
    }
}