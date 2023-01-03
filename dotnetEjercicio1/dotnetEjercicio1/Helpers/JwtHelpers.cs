using System.Security.Claims;
using dotnetEjercicio1.Models.DataModels;

namespace dotnetEjercicio1.Helpers
{
    public static class JwtHelpers
    {

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyy HH:mm:ss tt"))
            };

            if(userAccounts.UserName == "admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "administrator"));
            }else if (userAccounts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "user 1"));
            }
        }
    }
}
