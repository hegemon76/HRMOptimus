using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Account.Command.Registration
{
    public class RegistrationCommand : IRequest<string>
    {
        public RegistrationVm Registration { get; set; }
    }
}
