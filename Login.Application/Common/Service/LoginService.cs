using Login.Application.Abstract.Interface.Authentication;
using Login.Application.Abstract.Interface.Services;
using Login.Application.Common.Entities;
using Login.Application.Login.Query;
using MediatR;
using ErrorOr;

namespace Login.Application.Common.Service
{
    public class LoginService : ILoginService
    {
        private readonly ITokenGenerator _jwtTokenGenerator;
        private ISender _mediatR;

        public LoginService(ITokenGenerator jwtTokenGenerator, ISender mediatR)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _mediatR = mediatR;
        }

        public async Task<ErrorOr<TokenResponse>> GenerateToken(string email, string firstName, string lastName)
        {
            await Task.CompletedTask;
            try
            {
                var token = _jwtTokenGenerator.GenerateJwtToken(email, firstName, lastName);
                return new TokenResponse(token);

            }
            catch(Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }
        }

        public async Task<ErrorOr<LoginResponseWithToken>> Login(LoginQuery loginQuery)
        {
            var result = await _mediatR.Send(loginQuery);

            if (result.IsError)
            {
                return result.FirstError;
            }
            else
            {
                return GetLoginResponseWithToken(result.Value);
            }
        }

        private LoginResponseWithToken GetLoginResponseWithToken(LoginQueryResponse queryResponse)
        {
            var token = _jwtTokenGenerator.GenerateJwtToken(queryResponse.Email, queryResponse.FirstName, queryResponse.LastName);
            return new LoginResponseWithToken(queryResponse, token);
        }
    }
}
