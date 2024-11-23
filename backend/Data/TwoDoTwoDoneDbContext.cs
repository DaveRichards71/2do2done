
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TwoDoTwoDoneDbContext : DbContext
    {
        public TwoDoTwoDoneDbContext(DbContextOptions<TwoDoTwoDoneDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Task>()
                .HasOne(t => t.Author)
                .WithMany()
                .HasForeignKey("AuthorId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Domain.Task>()
                .HasOne(t => t.AssignedTo)
                .WithMany()
                .HasForeignKey("AssignedToId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.AssignsTasksTo)
                .WithMany(u => u.AcceptsTasksFrom)
                .UsingEntity(j => j.ToTable("UserUser"));

            // Seed Data 
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Email = "will@email.com",
                        Password = "ChangeMe!",
                        FirstName = "Will",
                        LastName = "Richards",
                        Mobile = "1234567890",
                        CreatedDate = DateTime.Now
                    },
                    new User
                    {
                        Id = 2,
                        Email = "charlie@email.com",
                        Password = "ChangeMe!",
                        FirstName = "Charlie",
                        LastName = "Houdini",
                        Mobile = "2345678901",
                        CreatedDate = DateTime.Now
                    });
        }
    }
}
