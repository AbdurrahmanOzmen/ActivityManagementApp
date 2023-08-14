using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.ServiceCollectionExtensions
{
    public static class AuthenticationExtensions
    {
        public static void BuildJWTAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = "FGDEVHOUSE",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("47d47f87f2f3609cbadd3d4d9f03ba3bf3107d10de5d80f38c194d1c4d483b1a")),
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(context.Principal.Claims));

                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception is SecurityTokenExpiredException) throw new Exception("Token süresi doldu.");

                        return Task.FromException(context.Exception);
                    }
                };
            });
        }
    }
}
