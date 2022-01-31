using MediatR;

namespace HRMOptimus.Application.Account.Command.Password.ChangePassword
{
    public class ChangePasswordCommand : IRequest
    {
        public ChangePasswordVm PasswordVm { get; set; }
    }
}