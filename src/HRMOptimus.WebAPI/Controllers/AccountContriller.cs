using HRMOptimus.Application.Account.Command.Logout;
using HRMOptimus.Application.Account.Command.Registration;
using HRMOptimus.Application.Account.Query.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    public class AccountContriller : BaseController
    {
        [HttpPost]
        [Route("api/register")]
        public async Task<ActionResult<string>> Register(RegistrationVm model)
        {
            var id = await Mediator.Send(new RegistrationCommand() { Registration = model });

            return id;
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<ActionResult<LoginVm>> Login(string username, string email, string password)
        {
            var user = await Mediator.Send(new LoginQuery() { Email = email, Password = password, Username = username });

            return user;
        }

        [HttpPost]
        [Route("api/logout")]
        public async Task<ActionResult<string>> Logout(LogoutVm logoutVm)
        {
            var msg = await Mediator.Send(new LogoutCommand() {});

            return msg;
        }
    }
}
