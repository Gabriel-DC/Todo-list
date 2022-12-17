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

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos => Set<TodoItem>();

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    base.OnConfiguring(options);
        //    //if (!options.IsConfigured)
        //    //{
        //    //    //options.UseSqlServer("TESTE");
        //    //}
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todo");
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(8000).HasColumnType("varchar(8000)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(120)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");

            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);
            modelBuilder.Entity<TodoItem>().HasIndex(x => x.User);
            base.OnModelCreating(modelBuilder);
        }
    }
}
