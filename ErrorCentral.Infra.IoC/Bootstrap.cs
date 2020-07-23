using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Application.Services;
using ErrorCentral.Data;
using ErrorCentral.Data.Repository;
using ErrorCentral.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorCentral.Infra.IoC
{
    public class Bootstrap
    {
        public static void ServiceRegistry(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IOrganizationService, OrganizationService>();

            services.AddDbContext<Context>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DbConn")));
        }
    }
}