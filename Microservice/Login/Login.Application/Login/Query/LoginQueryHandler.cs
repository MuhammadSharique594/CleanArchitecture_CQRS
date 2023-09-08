using ErrorOr;
using Login.Application.Abstract.Interface.Authentication;
using Login.Application.Abstract.Interface.Repositories;
using Login.Application.Common.QueryCommandHandler;
using Login.Domain.User;
using MediatR;

namespace Login.Application.Login.Query
{
    public class LoginQueryHandler : BaseQueryCommandHandler<LoginQuery, ErrorOr<LoginQueryResponse>>
    {
        public LoginQueryHandler(ITokenGenerator jwtTokenGenerator, ILoginRepository loginRepository) : base(jwtTokenGenerator, loginRepository) { } 

        public async override Task<ErrorOr<LoginQueryResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var result = await _loginRepository.Login(request.Email, request.Password);

            if(result.IsError)
            {
                return result.FirstError;
            }

            var user = result.Value;

            return MapAuthResult(user);
        }

        private static LoginQueryResponse MapAuthResult(User user)
        {
            return new LoginQueryResponse(user.Id, user.Email!, user.FirstName!, user.LastName!);
        }
    }
}
