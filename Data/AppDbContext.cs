namespace UserManagerService.Data
{
    using Microsoft.EntityFrameworkCore;
    using UserManagerService.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }

}

//my db gonna run locally using SQLite