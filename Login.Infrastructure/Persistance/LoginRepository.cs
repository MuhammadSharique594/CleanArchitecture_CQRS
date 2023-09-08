using ErrorOr;
using Login.Application.Abstract.Interface.Repositories;
using Login.Application.Common.Errors;
using Login.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Persistance
{
    public class LoginRepository : ILoginRepository
    {
        private readonly static List<User> _users = new();

        public async Task<ErrorOr<User>> Login(string email, string password)
        {
            await Task.CompletedTask;

            var user =  _users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if(user is not null)
            {
                return user;
            }

            return LoginError.UserNotFound;
        }

        public async Task<ErrorOr<User>> SignUp(string email, string password, string firstName, string lastName)
        {
            await Task.CompletedTask;

            if(_users.Any(x => x.Email == email))
            {
                return LoginError.EmailAlreadyExists;
            }

            var user = User.Create(email, password, firstName, lastName);

            _users.Add(user);

            return user;
        }
    }
}
