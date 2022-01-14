using MediatR;

namespace HRMOptimus.Application.Account.Command.Password.ConfirmPassword
{
    public class ConfirmPasswordCommand : IRequest
    {
        public string Token { get; set; }
    }
}