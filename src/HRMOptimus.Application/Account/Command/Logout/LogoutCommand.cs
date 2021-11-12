using MediatR;

namespace HRMOptimus.Application.Account.Command.Logout
{
    public class LogoutCommand : IRequest<string>
    {
        public LogoutVm LogoutVm { get; set; }
    }
}
