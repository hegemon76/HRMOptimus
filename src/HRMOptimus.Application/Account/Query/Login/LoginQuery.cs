using MediatR;

namespace HRMOptimus.Application.Account.Query.Login
{
    public class LoginQuery :IRequest<LoginVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
