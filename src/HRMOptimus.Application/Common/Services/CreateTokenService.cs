using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace HRMOptimus.Application.Common.Services
{
    public class CreateTokenService : ICreateTokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IHRMOptimusDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateTokenService(IConfiguration config, IHRMOptimusDbContext context, UserManager<ApplicationUser> userManager)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _context = context;
            _userManager = userManager;
        }

        public string CreateToken(string userId)
        {
            var user = _context.ApplicationUsers
                .Include(x => x.Employee)
                .FirstOrDefault(x => x.Id == userId);

            var roles = _userManager.GetRolesAsync(user);

            var claims = new List<Claim>();
            claims.Add(new Claim("userId", userId));
            claims.Add(new Claim("employeeId", user.Employee.Id.ToString()));
            claims.Add(new Claim("fullName", user.Employee.FullName));
            claims.Add(new Claim("gender", ((int)user.Employee.Gender).ToString()));

            foreach (var role in roles.Result)
            {
                claims.Add(new Claim("role", role));
            }

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}