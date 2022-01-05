using MediatR;

namespace HRMOptimus.Application.Account.Command.SetRoles
{
    public class SetRolesCommand : IRequest<Unit>
    {
        public SetRolesVm AddToRoleVm { get; set; }
    }
}