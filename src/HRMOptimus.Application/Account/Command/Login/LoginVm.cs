using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Application.Account.Command.Login
{
    public class LoginVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Token { get; set; }
    }
}
