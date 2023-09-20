using Microsoft.IdentityModel.Tokens;

namespace API
{
    public class Helper
    {
        public static bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            return false;
        }
    }
}
