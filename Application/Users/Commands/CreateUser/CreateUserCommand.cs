using Application.Dtos;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public UserDto NewUser { get; }

        public CreateUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }
    }
}
