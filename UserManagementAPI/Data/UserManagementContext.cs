using UserManagementAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace UserManagementAPI.Data
{
    public class UserManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role>  Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=UserManagementDB;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
