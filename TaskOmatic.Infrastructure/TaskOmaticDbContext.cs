using Microsoft.EntityFrameworkCore;
using TaskOmatic.Domain.Entities;

namespace TaskOmatic.Infrastructure;

public class TaskOmaticDbContext : DbContext
{
    public TaskOmaticDbContext(DbContextOptions<TaskOmaticDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskEntry> Task { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Task-User relationship
        modelBuilder.Entity<TaskEntry>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.UserID)
            .OnDelete(DeleteBehavior.SetNull);

        // Default value for soft-delete flags
        modelBuilder.Entity<TaskEntry>()
            .Property(t => t.IsDeleted)
            .HasDefaultValue(false);

        modelBuilder.Entity<User>()
            .Property(u => u.IsDeleted)
            .HasDefaultValue(false);
        
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "ironman", FirstName = "Tony", LastName = "Stark", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 2, Username = "cap", FirstName = "Steve", LastName = "Rogers", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 3, Username = "hulk", FirstName = "Bruce", LastName = "Banner", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 4, Username = "thor", FirstName = "Thor", LastName = "Odinson", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 5, Username = "natasha", FirstName = "Natasha", LastName = "Romanoff", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },

            new User { Id = 6, Username = "superman", FirstName = "Clark", LastName = "Kent", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 7, Username = "batman", FirstName = "Bruce", LastName = "Wayne", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 8, Username = "wonderwoman", FirstName = "Diana", LastName = "Prince", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 9, Username = "flash", FirstName = "Barry", LastName = "Allen", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 10, Username = "aquaman", FirstName = "Arthur", LastName = "Curry", Created = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc) }
        );

    }
}