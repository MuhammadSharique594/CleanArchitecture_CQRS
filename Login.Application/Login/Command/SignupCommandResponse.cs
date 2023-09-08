using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Login.Command
{
    public record SignupCommandResponse(string Email, string FirstName, string LastName);
}
