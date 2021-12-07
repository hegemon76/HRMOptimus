using MediatR;

namespace HRMOptimus.Application.Account.Command.Login
{
    public class LoginCommand :IRequest<LoginVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
