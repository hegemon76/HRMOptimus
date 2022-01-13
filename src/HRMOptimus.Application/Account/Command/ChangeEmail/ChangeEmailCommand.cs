using MediatR;

namespace HRMOptimus.Application.Account.Command.ChangeEmail
{
    public class ChangeEmailCommand : IRequest
    {
        public ChangeEmailVm EmailVm { get; set; }
    }
}