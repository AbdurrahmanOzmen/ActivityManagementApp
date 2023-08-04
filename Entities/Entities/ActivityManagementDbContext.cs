using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Entities.Entities
{
    public class ActivityManagementDbContext : DbContext
    {
        private IHttpContextAccessor _httpContextAccessor;
        public IConfiguration Configuration { get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=185.242.161.205;Initial Catalog=ActivityManagementDB;User Id=abdurrahman.ozmen;Password=Ao2023;MultipleActiveResultSets=True;Pooling=false;");
            }
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }


        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSaveChanges()
        {
            var now = DateTime.Now;

            //TODO: giriş yapan kullanıcı olunca açılacak.
            //var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value?.Trim();
            var userId = 1;
            
            var currentUser = userId != null ? Convert.ToInt32(userId) : 1;

            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified).ToArray())
            {
                var entity = entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedUserId = currentUser;

                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedDate = now;
                    entity.UpdatedUserId = currentUser;
                }
            }
        }
    }
}
