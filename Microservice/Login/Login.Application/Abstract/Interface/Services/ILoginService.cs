using ErrorOr;
using Login.Application.Common.Entities;
using Login.Application.Login.Query;

namespace Login.Application.Abstract.Interface.Services
{
    public interface ILoginService
    {
        Task<ErrorOr<LoginResponseWithToken>> Login(LoginQuery loginQuery);

        Task<ErrorOr<string>> GenerateToken(string email, string firstName, string lastName);
    }
}
