using System.Data.Entity;

namespace Users
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}