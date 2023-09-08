using Login.Application.Abstract.Interface.Authentication;
using Login.Application.Abstract.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Common.QueryCommandHandler
{
    public abstract class BaseQueryCommandHandler<TReq, TRes> : IRequestHandler<TReq, TRes> where TReq : IRequest<TRes>
    {
        protected readonly ITokenGenerator? _jwtTokenGenerator;

        protected readonly ILoginRepository? _loginRepository;

        protected BaseQueryCommandHandler(ITokenGenerator jwtTokenGenerator, ILoginRepository loginRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _loginRepository = loginRepository;
        }

        protected BaseQueryCommandHandler(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        protected BaseQueryCommandHandler(ITokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public abstract Task<TRes> Handle(TReq request, CancellationToken cancellationToken);

    }
}
