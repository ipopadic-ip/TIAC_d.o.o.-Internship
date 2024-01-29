using Microsoft.EntityFrameworkCore;
using P1TaskFlow.Models;

namespace P1TaskFlow.DataAcess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) 
        { 

        }
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<TodoTaskGropup> todoTaskGropups { get; set; }
        public DbSet<User> authentications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                rel.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Authentication>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
