using HRMOptimus.Application.Account.Command.Registration;
using HRMOptimus.Application.Account.Query.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        [Route("api/register")]
        public async Task<ActionResult<string>> Register([FromBody] RegistrationVm model)
        {
            var id = await Mediator.Send(new RegistrationCommand() { Registration = model});

            return id;
        }

        [HttpGet]
        [Route("api/login")]
        public async Task<ActionResult<LoginVm>> Login([FromBody] LoginQuery dto)
        {
            var user = await Mediator.Send(new LoginQuery() { Email = dto.Email, Password = dto.Password });

            return user;
        }
    }
}
