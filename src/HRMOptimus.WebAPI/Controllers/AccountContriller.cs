using HRMOptimus.Application.User.Query.Registration.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [Route("api/register")]
    public class AccountContriller : BaseController
    {
        [HttpPost]
       public async Task<ActionResult<string>> Register(RegistrationVm model)
        {
            var id = await Mediator.Send(new RegistrationCommand() { Registration = model });
            return id;
        }
    }
}
