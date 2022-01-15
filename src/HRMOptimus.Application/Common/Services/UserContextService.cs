using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Common.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly string _token;
        private readonly UserManager<ApplicationUser> _userManager;
        private int? _employeeId;
        private string _userId;
        private ApplicationUser _applicationUser;

        public UserContextService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _token = httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (!string.IsNullOrWhiteSpace(_token))
                decodeToken();
        }

        private void decodeToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(_token);
            _employeeId = int.Parse(jsonToken.Payload.First(claim => claim.Key == "employeeId").Value.ToString());
            _userId = jsonToken.Payload.First(claim => claim.Key == "userId").Value.ToString();
            if (_userId != null)
                _applicationUser = _userManager.FindByIdAsync(_userId).Result;
        }

        public string GetUserId => string.IsNullOrWhiteSpace(_userId) ? null : _userId;

        public int? GetEmployeeId => _employeeId == 0 || _employeeId == null ? 0 : (int)_employeeId;

        public List<string> GetRoles()
        {
            var roles = _userManager.GetRolesAsync(_applicationUser).Result.ToList();
            return roles;
        }
    }
}