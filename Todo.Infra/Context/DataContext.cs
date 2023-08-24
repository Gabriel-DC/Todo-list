using Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Todo.Infra.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos => Set<TodoItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todo");
            modelBuilder.Entity<TodoItem>().Property(x => x.Id).HasColumnType("char(36)");
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(255).HasColumnType("varchar(255)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("boolean");

            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);
            modelBuilder.Entity<TodoItem>().HasIndex(x => x.User);
            base.OnModelCreating(modelBuilder);
        }
    }
}
