using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Services;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Password.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserContextService _userService;
        private readonly EmailService _emailService;
        private readonly IHRMOptimusDbContext _dbContext;

        public ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager, IUserContextService userService,
            EmailService emailService, IHRMOptimusDbContext dbContext)
        {
            _userManager = userManager;
            _userService = userService;
            _emailService = emailService;
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;
            var appUser = _userManager.FindByIdAsync(userId).Result;
            
            var newPassword = _userManager.PasswordHasher.HashPassword(appUser, request.PasswordVm.NewPassword);
            appUser.NewPassword = newPassword;

            var token = _userManager.GeneratePasswordResetTokenAsync(appUser).Result;

            byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

            _emailService.SendEmail(codeEncoded);

            _dbContext.ApplicationUsers.Update(appUser);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
