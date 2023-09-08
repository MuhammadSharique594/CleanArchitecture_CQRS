using ErrorOr;
using Login.Application.Abstract.Interface.Authentication;
using Login.Application.Abstract.Interface.Repositories;
using Login.Application.Common.QueryCommandHandler;
using Login.Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Login.Command
{
    public class SignupCommandHandler : BaseQueryCommandHandler<SignupCommand, ErrorOr<SignupCommandResponse>>
    {
        public SignupCommandHandler(ILoginRepository loginRepository) : base(loginRepository) { }

        public async override Task<ErrorOr<SignupCommandResponse>> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            var result = await _loginRepository?.SignUp(request.Email, request.Password, request.FirstName, request.LastName);

            if(result.IsError)
            {
                return result.FirstError;
            }

            return MapAuthResult(result.Value);
        }

        private static SignupCommandResponse MapAuthResult(User user)
        {
            return new SignupCommandResponse(user.Email!, user.FirstName!, user.LastName!);
        }
    }
}
