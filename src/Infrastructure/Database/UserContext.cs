using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace User.Infrastructure.Database
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<Core.Entities.User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Core.Entities.User>().ToTable("users");
            builder.Entity<Core.Entities.User>().Property(x => x.Id).HasColumnName("id");
            
            builder.Entity<Core.Entities.User>().Property(x => x.UserName).HasColumnName("username");
            builder.Entity<Core.Entities.User>().Property(x => x.Password).HasColumnName("password");
            builder.Entity<Core.Entities.User>().Property(x => x.FirstName).HasColumnName("firstname");
            builder.Entity<Core.Entities.User>().Property(x => x.LastName).HasColumnName("lastname");
        }
    }
}