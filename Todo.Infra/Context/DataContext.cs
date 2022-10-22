using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<TodoItem>().ToTable("Todo");
            model.Entity<TodoItem>().Property(x => x.Id);
            model.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            model.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(120)");
            model.Entity<TodoItem>().Property(x => x.Date);
            model.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");

            model.Entity<TodoItem>().HasKey(x => x.Id);
            model.Entity<TodoItem>().HasIndex(x => x.User);
        }
    }
}
