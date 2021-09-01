using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TaskManagementDbContext:DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TasksHistory> TasksHistory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUsers);
            modelBuilder.Entity<Task>(ConfigureTasks);
            modelBuilder.Entity<TasksHistory>(ConfigureTasksHistory);
        }

        private void ConfigureTasks(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.DueDate);
            builder.Property(t => t.Priority).HasMaxLength(1);
            builder.Property(t => t.Remarks).HasMaxLength(500);
        }
        private void ConfigureTasksHistory(EntityTypeBuilder<TasksHistory> builder)
        {
            builder.ToTable("Tasks History");
            builder.HasKey(th => th.TaskId);
            builder.Property(th => th.Title).HasMaxLength(50);
            builder.Property(th => th.Description).HasMaxLength(500);
            builder.Property(th => th.DueDate);
            builder.Property(th => th.Completed);
            builder.Property(th => th.Remarks).HasMaxLength(500);
        }
        private void ConfigureUsers(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(10);
            builder.Property(u => u.Mobileno).HasMaxLength(50);
        }

        

        

    }
}
