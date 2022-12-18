using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MockInterview.Business.Helper;
using MockInterview.Business.Interface;
using MockInterview.Business.Services;
using MockInterview.Domain.Models.AuthOption;
using System.Text;

namespace MockInterview.Business.Extentions
{
    public static class ServiseRegistration
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingInitializer));

            services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
            services.AddScoped<IClientServiceAsync, ClientServiceAsync>();
            services.AddScoped<IFileServiceAsync, FileServiceAsync>();

            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });



        }
    }
}
