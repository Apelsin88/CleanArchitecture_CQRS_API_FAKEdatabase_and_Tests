using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<User> AddUser(User user)
        {
            _realDatabase.Users.Add(user);
            await _realDatabase.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = _realDatabase.Users.ToList();
            return users;
        }

        public async Task<User> GetUser(UserDto userDto)
        {
            var user = _realDatabase.Users.FirstOrDefault(user => user.UserName == userDto.UserName && user.Password == userDto.Password);
            
            return user;
        }
    }
}
