using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Application.Abstract.Interface.Authentication
{
    public interface ITokenGenerator
    {
        string GenerateJwtToken(string email, string firstName, string lastName);
    }
}
