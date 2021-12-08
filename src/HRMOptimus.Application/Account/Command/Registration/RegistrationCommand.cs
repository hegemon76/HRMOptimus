using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationCommand : IRequest<IActionResult>
    {
        public RegistrationVm Registration { get; set; }

    }
}
