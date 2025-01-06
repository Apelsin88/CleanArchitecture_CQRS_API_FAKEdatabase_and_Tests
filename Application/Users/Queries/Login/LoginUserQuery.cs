using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.Login
{
    public class LoginUserQuery : IRequest<string>
    {
        public UserDto LoginUser { get; }

        public LoginUserQuery(UserDto loginUser)
        {
            LoginUser = loginUser;
        }
    }
}
