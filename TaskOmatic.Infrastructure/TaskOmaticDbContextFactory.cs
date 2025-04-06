using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskOmatic.Infrastructure;

public class TaskOmaticDbContextFactory : IDesignTimeDbContextFactory<TaskOmaticDbContext>
{
    public TaskOmaticDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TaskOmaticDbContext>();
        optionsBuilder.UseSqlite("Data Source=taskomatic.db"); // You can also load from appsettings if needed

        return new TaskOmaticDbContext(optionsBuilder.Options);
    }
}