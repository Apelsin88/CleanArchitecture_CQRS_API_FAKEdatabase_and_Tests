using Application.Interfaces.RepositoryInterfaces;
using Application.Users.Queries.Login.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenHelper _tokenHelper;

        public LoginUserQueryHandler(IUserRepository userRepository, TokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUser(request.LoginUser);

            if (user == null)
            {
                throw new UnauthorizedAccessException("wrong username or password");
            }

            string token = _tokenHelper.GenerateJwtToken(user.Result);

            return Task.FromResult(token);
        }
    }
}
