using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Application.Services;
using ErrorCentral.Data;
using ErrorCentral.Data.Repository;
using ErrorCentral.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ErrorCentral.Infra.IoC
{
    public class Bootstrap
    {
        public static void ServiceRegistry(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IErrorRepository, ErrorRepository>();

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IErrorService, ErrorService>();

            services.AddDbContext<Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConn")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.AllowedUserNameCharacters = String.Empty;
                options.User.RequireUniqueEmail = true;

                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<Context>();
        }
    }
}