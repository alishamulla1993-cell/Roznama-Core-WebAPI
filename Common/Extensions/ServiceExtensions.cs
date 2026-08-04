using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Roznama.Config;
using System.Text;
using Roznama.Models.Auth;
using Roznama.Models.Notice;
using Roznama.Modules.Auth;
using Roznama.Modules.Notice;

namespace Roznama.Common.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            // bind config
            services.Configure<AppSettings>(config);

            // register DI
            services.AddScoped<AuthRepository>();
            services.AddScoped<NoticeRepository>();

            return services;
        }

        public static IServiceCollection AddAppCors(this IServiceCollection services, IConfiguration config)
        {
            var allowedOrigins = config.GetSection("AllowedOrigins").Get<string[]>();

            if (allowedOrigins == null || allowedOrigins.Length == 0)
            {
                allowedOrigins = new[] { "http://localhost:5173" };
            }

            services.AddCors(options =>
            {
                options.AddPolicy("AppCors", policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var jwt = config.GetSection("Jwt").Get<JwtSettings>() ?? new JwtSettings();

            var keyBytes = Encoding.UTF8.GetBytes(jwt.Key);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwt.Issuer,
                        ValidAudience = jwt.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                        ClockSkew = TimeSpan.FromMinutes(1)
                    };
                });

            return services;
        }
    }
}