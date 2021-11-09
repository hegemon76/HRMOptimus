using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.User.Query.Login
{
    public class LoginQuery :IRequest<LoginVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
