using System.Collections.Generic;
using System;
using JWT.Algorithms;
using JWT.Builder;

namespace Api.Infrastructure.Helpers
{
    public static class JwtBuilderHelper
    {
        public static object Build(Dictionary<string, object> claims)
        {
            var expireDate = DateTime.Now.AddSeconds(36000);

            var builder = new JWT.Builder.JwtBuilder()
              .WithAlgorithm(new HMACSHA256Algorithm())
              .WithSecret("47d47f87f2f3609cbadd3d4d9f03ba3bf3107d10de5d80f38c194d1c4d483b1a")
              .AddClaim(ClaimName.AuthenticationTime, DateTime.UtcNow.ToString())
              .AddClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", new string[] { "User" })
              .IssuedAt(DateTime.Now)
              .ExpirationTime(expireDate)
              .Issuer("FGDEVHOUSE")
              .Id(Guid.NewGuid().ToString("N"));

            builder.AddClaims(claims);
            string token = builder.Encode();

            return new
            {
                access_token = token,
                expires_in = 36000,
                token_type = "bearer"
            };
        }
    }
}
