using HRMOptimus.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace HRMOptimus.Application.Common.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly string _token;
        private int? _employeeId;
        private string _userId;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _token = httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            decodeToken();
        }

        private void decodeToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(_token);
            _employeeId = int.Parse(jsonToken.Payload.First(claim => claim.Key == "employeeId").Value.ToString());
            _userId = jsonToken.Payload.First(claim => claim.Key == "userId").Value.ToString();
        }

        public string GetUserId => string.IsNullOrWhiteSpace(_userId) ? null : _userId;

        public int? GetEmployeeId => _employeeId == 0 || _employeeId == null ? 0 : (int)_employeeId;

        public List<ClaimsPrincipal> Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}