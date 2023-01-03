using dotnetEjercicio1.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace dotnetEjercicio1
{
    public static class AddJwTokenServicesExtensions
    {
        public static void AddJwTokenServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            // Add JWT Settings
            var bindJwtSetting = new JwtSettings();
            Configuration.Bind("JsonWebToquenKeys", bindJwtSetting);
            // Add Singleton of Jwt Settings
            Services.AddSingleton(bindJwtSetting);

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtSetting.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSetting.IssuerSigningKey)),
                    ValidateIssuer = bindJwtSetting.ValidateIssuer,
                    ValidIssuer = bindJwtSetting.ValidIssuer,
                    ValidAudience = bindJwtSetting.ValidAudice,
                    ValidateAudience = bindJwtSetting.ValidateAudience,
                    RequireExpirationTime = bindJwtSetting.RequireExpiretionTime,
                    ValidateLifetime = bindJwtSetting.ValidateLifeTime,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });
        }
    }
}
