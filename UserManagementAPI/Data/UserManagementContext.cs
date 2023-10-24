using UserManagementAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace UserManagementAPI.Data
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role>  Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
