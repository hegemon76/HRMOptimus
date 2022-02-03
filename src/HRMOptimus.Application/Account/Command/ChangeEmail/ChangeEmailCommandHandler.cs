using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Services;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _context;
        private readonly EmailService _emailService;

        public ChangeEmailCommandHandler(UserManager<ApplicationUser> userManager, IHRMOptimusDbContext context
            , EmailService emailService)
        {
            _userManager = userManager;
            _context = context;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.EmailVm.ApplicationUserId);
            
            user.NewMail = request.EmailVm.NewEmail;
            user.EmailConfirmed = false;
            
            _context.ApplicationUsers.Update(user);

            var token = _userManager.GenerateChangeEmailTokenAsync(user, request.EmailVm.NewEmail).Result;

            byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

            _emailService.SendResetEmailRequest(codeEncoded);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}