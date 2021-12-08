using MediatR;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationCommand : IRequest
    {
        public RegistrationVm Registration { get; set; }
    }
}