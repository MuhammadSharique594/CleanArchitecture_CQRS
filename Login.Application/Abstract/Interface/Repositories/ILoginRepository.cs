using ErrorOr;
using Login.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Abstract.Interface.Repositories
{
    public interface ILoginRepository
    {
        Task<ErrorOr<User>> Login(string email, string password);
        Task<ErrorOr<User>> SignUp(string email, string password, string firstName, string lastName);
    }
}
