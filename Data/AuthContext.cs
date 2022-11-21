using AuthChoco.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthChoco.Data
{
public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}