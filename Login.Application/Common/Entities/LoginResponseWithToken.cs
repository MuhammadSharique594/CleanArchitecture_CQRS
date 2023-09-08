using Login.Application.Login.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Common.Entities
{
    public record LoginResponseWithToken(LoginQueryResponse LoginQueryResponse, string? Token);
}
