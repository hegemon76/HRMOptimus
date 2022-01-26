using HRMOptimus.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.IntegrationTests
{
    public class FakeUserFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            claimsPrincipal.AddIdentity(new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Role, UserRoles.User.ToString()),
                 }));

            context.HttpContext.User = claimsPrincipal;

            await next();
        }
    }
}