using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DelfostiChallenge.API.Extensions.Authentication
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                IConfigurationSection configJwtSecretKey = configuration.GetRequiredSection("Jwt:SecretKey");
                var key = Encoding.UTF8.GetBytes(configJwtSecretKey.Value);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false, /*true*/
                    ValidateAudience = false, /*true*/
                    RequireExpirationTime = false, /*true*/
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };

            });

            return services;
        }
    }
}
