﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using dotnetEjercicio1.Models.DataModels;
using Microsoft.IdentityModel.Tokens;

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
            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }

        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if(model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                //obtain SECRET KEY
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

                Guid Id;

                // Expires in 1 day

                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                //Validity of our token

                userToken.Validity = expireTime.TimeOfDay;

                // GENERATE OUR JWT

                var jwToken = new JwtSecurityToken(

                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudice,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256));

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);    
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;

                return userToken;
            }
            catch (Exception ex)
            {
                throw new Exception("error generating the JWT", ex);
            }
        }

    }
}
