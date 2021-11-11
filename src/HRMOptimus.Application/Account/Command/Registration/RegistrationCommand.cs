using MediatR;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationCommand : IRequest<string>
    {
        public RegistrationVm Registration { get; set; }

    }
}
