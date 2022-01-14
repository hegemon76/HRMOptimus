using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Password.ConfirmPassword
{
    public class ConfirmPasswordCommandHandler : IRequestHandler<ConfirmPasswordCommand>
    {
        private readonly IUserContextService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _dbContext;

        public ConfirmPasswordCommandHandler(IUserContextService userService
            , UserManager<ApplicationUser> userManager, IHRMOptimusDbContext dbContext)
        {
            _userService = userService;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ConfirmPasswordCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;
            var user = _userManager.FindByIdAsync(userId).Result;

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(request.Token);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var paswordChanged = await _userManager.ResetPasswordAsync(user, codeDecoded, user.NewPassword);

            if (paswordChanged.Succeeded)
            {
                user.PasswordHash = user.NewPassword;
                user.NewPassword = null;
                _dbContext.ApplicationUsers.Update(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}