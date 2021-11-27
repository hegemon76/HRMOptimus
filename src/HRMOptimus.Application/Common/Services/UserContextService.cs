using HRMOptimus.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace HRMOptimus.Application.Common.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly string _token;
        private int? _employeeId;
        private string _userId;
        private string _fullName;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _token = httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ","");
            decodeToken();
        }
        private void decodeToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(_token);
            _employeeId = int.Parse(jsonToken.Payload.First(claim => claim.Key== "EmployeeId").Value.ToString());
            _userId = jsonToken.Payload.First(claim => claim.Key == "UserId").Value.ToString();
        }

        private int? Parse(int v)
        {
            throw new NotImplementedException();
        }

        public string GetUserId => string.IsNullOrWhiteSpace(_userId) ? null : _userId;

        public int? GetEmployeeId => _employeeId == 0 || _employeeId == null ? 0 : (int)_employeeId;

        public string GetUserFullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ClaimsPrincipal> Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
