using MediatR;

namespace HRMOptimus.Application.Account.Command.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest
    {
        public string ConfirmationToken { get; set; }
    }
}