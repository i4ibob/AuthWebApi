using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Auxilary
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var authSettings = configuration.GetSection(nameof(AuthSettings))
                .Get<AuthSettings>();

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false, // Не проверяем издателя
                        ValidateAudience = false, // Не проверяем аудиторию
                        ValidateLifetime = true, // Проверяем время жизни токена
                        ValidateIssuerSigningKey = true, // Проверяем подпись токена
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.SecretKey)) // Подключаем секретный ключ
                    };

                    // Добавляем обработчик событий для получения токена из куков
                    o.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            // Проверяем, есть ли токен в куках
                            if (context.Request.Cookies.TryGetValue("myToken", out var token))
                            {
                                context.Token = token;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            return serviceCollection;
        }
    }

}



