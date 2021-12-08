using HRMOptimus.Application.Account.Command.Login;
using HRMOptimus.Application.Account.Command.Logout;
using HRMOptimus.Application.Account.Command.Registration;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [ApiController]
    public class AccountController : BaseController
    {
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] RegistrationVm model)
        {
            return await Mediator.Send(new RegistrationCommand() { Registration = model });
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<ActionResult<LoginVm>> Login([FromBody] LoginCommand dto)
        {
            return await Mediator.Send(new LoginCommand() { Email = dto.Email, Password = dto.Password });
        }

        [HttpGet]
        [Route("api/logout")]
        public async Task<ActionResult<string>> Logout()
        {
            return await Mediator.Send(new LogoutCommand() { });
        }
    }
}