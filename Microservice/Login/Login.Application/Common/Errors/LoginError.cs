using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Common.Errors
{
    public static class LoginError
    {
        public static Error EmailAlreadyExists = Error.Conflict("Email", "Email Already Exists");
        public static Error UserNotFound = Error.NotFound("Email/Password", "Invalid Email/Password");
    }
}
