using HRMOptimus.Application.Account.Command.ChangeEmail;
using HRMOptimus.Application.Account.Command.ConfirmEmail;
using HRMOptimus.Application.Account.Command.Login;
using HRMOptimus.Application.Account.Command.Logout;
using HRMOptimus.Application.Account.Command.Registration;
using HRMOptimus.Application.Account.Command.SetRoles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [Route("/api")]
    [ApiController]
    public class AccountController : BaseController
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationVm model)
        {
            await Mediator.Send(new RegistrationCommand() { Registration = model });

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginVm>> Login([FromBody] LoginCommand dto)
        {
            return await Mediator.Send(new LoginCommand() { Email = dto.Email, Password = dto.Password });
        }

        [HttpGet]
        [Route("logout")]
        public async Task<ActionResult<string>> Logout()
        {
            return await Mediator.Send(new LogoutCommand());
        }

        [HttpPost]
        [Route("setRoles")]
        public async Task<IActionResult> SetRoles([FromBody] SetRolesVm model)
        {
            await Mediator.Send(new SetRolesCommand() { AddToRoleVm = model });

            return Ok();
        }

        [HttpPost]
        [Route("changeEmail")]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailVm model)
        {
            await Mediator.Send(new ChangeEmailCommand() { EmailVm = model });

            return Ok();
        }

        [HttpPost]
        [Route("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token)
        {
            await Mediator.Send(new ConfirmEmailCommand() { ConfirmationToken = token });

            return Ok();
        }
    }
}