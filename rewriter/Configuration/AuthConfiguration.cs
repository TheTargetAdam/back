using Db.Context.Context;
using Db.Entities;
using Db.Entities.User_Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using rewriter.Settings.Interface;
using rewriter.Shared.Common.Security;
using Shared.Common.Auth;

namespace rewriter.api.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAppAuth(this IServiceCollection services)
        {
            //services
            //    .AddIdentity<IdUser, IdentityRole<Guid>>(opt =>
            //    {
            //        opt.Password.RequiredLength = 0;
            //        opt.Password.RequireDigit = false;
            //        opt.Password.RequireLowercase = false;
            //        opt.Password.RequireUppercase = false;
            //        opt.Password.RequireNonAlphanumeric = false;
            //    })
            //    .AddEntityFrameworkStores<MainDbContext>()
            //    .AddUserManager<UserManager<IdUser>>()
            //    .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,
                            LifetimeValidator = CustomLifetimeValidator,
                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });


            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(AppScopes.OrderRead, policy => policy.RequireClaim("scope", AppScopes.OrderRead));
            //    options.AddPolicy(AppScopes.OrderWrite, policy => policy.RequireClaim("scope", AppScopes.OrderWrite));
            //});

            return services;
        }
        public static bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                return DateTime.UtcNow < expires;
            }
            return false;
        }
        public static IApplicationBuilder UseAppAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }
    }
}
