using HRMOptimus.Domain.Enums;
using System.Collections.Generic;

namespace HRMOptimus.Application.Account.Command.SetRoles
{
    public class SetRolesVm
    {
        public string Email { get; set; }
        public List<UserRoles> UserRoles { get; set; }
    }
}