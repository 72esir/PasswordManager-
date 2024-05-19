using Microsoft.EntityFrameworkCore;

namespace PasswordManeger
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PasswordEntry> PasswordEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Accounts.db");
        }
    }
}