using ApprovalManagementAPI.Services;
using ApprovalManagementAPI.Services.Interfaces;
using ApprovalManagementAPI.DataModel.Entities;
using ApprovalManagementAPI.DataModel.Repository;
using ApprovalManagementAPI.DataModel.Repository.Interface;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ApprovalManagementAPI.Mapper;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace ApprovalManagementAPI.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration Configuration)
        {
           
            services.AddScoped<IBudgetRepository, BudgetRequestRepository>();
            services.AddScoped<IBudgetRequestService, BudgetRequestService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddCors();
            services.AddAutoMapper(typeof(UserMapper));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters =
                new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false

                });


        }
    }
}
