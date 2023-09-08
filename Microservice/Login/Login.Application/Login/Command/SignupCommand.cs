using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Login.Command
{
    public record SignupCommand(string Email, string Password, string FirstName, string LastName) : IRequest<ErrorOr<SignupCommandResponse>>;
}
