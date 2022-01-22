using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;

namespace HRMOptimus.Application.Common.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDecodeTokenService _decodeTokenService;
        private ApplicationUser _applicationUser;

        public UserContextService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager,
                                  IDecodeTokenService decodeTokenService)
        {
            _userManager = userManager;
            _decodeTokenService = decodeTokenService;
            var token = httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (!string.IsNullOrWhiteSpace(token))
                _applicationUser = _decodeTokenService.decodeToken(token, userManager);
        }

        public string GetUserId => _applicationUser != null ? null : _applicationUser.Id;
        public string GetFullName => _applicationUser != null ? null : _decodeTokenService.FullName;
        public int? GetEmployeeId => _applicationUser != null ? _applicationUser.EmployeeId : null;

        public List<string> GetRoles()
        {
            var roles = _applicationUser != null ?
                        _userManager.GetRolesAsync(_applicationUser).Result.ToList() : new List<string>();

            return roles;
        }
    }
}