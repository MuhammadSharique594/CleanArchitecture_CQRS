﻿using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Login.Query
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<LoginQueryResponse>>;
}
