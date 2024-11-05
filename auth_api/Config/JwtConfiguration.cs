using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace auth_api.Config;

public static class JwtConfiguration
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtKey = configuration["ApplicationSettings:JWT_Secret"]
            ?.Replace("{JWT_SECRET}", Environment.GetEnvironmentVariable("JWT_SECRET"));
        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new Exception("JWT_SECRET env variable not found not found");
        }
        
        services.AddAuthentication(cfg =>
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.RequireHttpsMetadata = false;
            option.SaveToken = false;
            option.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8
                        .GetBytes(jwtKey)
                ),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}