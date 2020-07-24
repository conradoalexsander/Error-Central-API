using ErrorCentral.Data.Map;
using ErrorCentral.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ErrorCentral.Data
{
    public class Context : IdentityDbContext
    {
        public DbSet<Log> Log { get; set; }
        public DbSet<Organization> Organization { get; set; }

        public Context(DbContextOptions<Context> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new OrganizationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}