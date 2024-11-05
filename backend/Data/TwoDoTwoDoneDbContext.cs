
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TwoDoTwoDoneDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For Development Only!
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TwoDoTwoDone_EfCore; Encrypt=False");
        }

    }
}
