using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand>
    {
        private readonly IUserContextService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _dbContext;

        public ConfirmEmailCommandHandler(IUserContextService userService
            , UserManager<ApplicationUser> userManager, IHRMOptimusDbContext dbContext)
        {
            _userService = userService;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;
            var user = _userManager.FindByIdAsync(userId).Result;

            if (request.ConfirmationToken == null)
                throw new Exception("Token not provided");
            if (userId == null)
                throw new Exception("User not found");

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(request.ConfirmationToken);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var emailChanged = await _userManager.ChangeEmailAsync(user, user.NewMail, codeDecoded);
            if (emailChanged.Succeeded)
            {
                user.EmailConfirmed = false;
                user.NewMail = null;
                user.NormalizedEmail = user.Email.ToUpper();
                user.UserName = user.Email;
                user.NormalizedUserName = user.Email.ToUpper();

                _dbContext.ApplicationUsers.Update(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}