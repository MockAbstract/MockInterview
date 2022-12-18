using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MockInterview.Domain.Models.AuthOption
{
    public class AuthOptions
    {
        public const string ISSUER = "MyIssuer";
        public const string AUDIENCE = "MyAudience";
        public const string KEY = "ThereIsSecurityKey";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
