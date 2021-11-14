using HRMOptimus.Application.Account.Command.Login;
using HRMOptimus.Application.Account.Command.Logout;
using HRMOptimus.Application.Account.Command.Registration;
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

        [HttpPost]
        [Route("api/login")]
        public async Task<ActionResult<LoginVm>> Login([FromBody] LoginCommand dto)
        {
            var user = await Mediator.Send(new LoginCommand() { Email = dto.Email, Password = dto.Password });

            return user;
        }

        [HttpPost]
        [Route("api/logout")]
        public async Task<ActionResult<string>> Logout(LogoutVm logoutVm)
        {
            var msg = await Mediator.Send(new LogoutCommand());

            return msg;
        }
    }
}
