using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace HRMOptimus.Application.Common.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser _applicationUser;
        private string FullName { get; set; }

        public UserContextService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            var token = httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            decodeToken(token);
        }

        public string GetUserId => _applicationUser != null ? null : _applicationUser.Id;
        public string GetFullName => string.IsNullOrWhiteSpace(FullName) ? null : FullName;
        public int? GetEmployeeId => _applicationUser != null ? _applicationUser.EmployeeId : null;

        public List<string> GetRoles()
        {
            var roles = _applicationUser != null ?
                        _userManager.GetRolesAsync(_applicationUser).Result.ToList() : new List<string>();

            return roles;
        }

        private void decodeToken(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(token);

                FullName = jsonToken.Payload.First(claim => claim.Key == "fullName").Value.ToString();
                var userId = jsonToken.Payload.First(claim => claim.Key == "userId").Value.ToString();

                if (userId != null)
                {
                    _applicationUser = _userManager.FindByIdAsync(userId).Result;
                }
            }
        }
    }
}