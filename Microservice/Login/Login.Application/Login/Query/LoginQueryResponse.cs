using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Login.Query
{
    public record LoginQueryResponse(Guid UserId, string Email, string FirstName, string LastName);
}
