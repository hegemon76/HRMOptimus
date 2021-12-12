using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, string>
    {
        public LogoutCommandHandler()
        {
        }

        public async Task<string> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return "Logged off";
        }
    }
}