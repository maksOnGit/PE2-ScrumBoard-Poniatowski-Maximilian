using Microsoft.EntityFrameworkCore;
using ScrumBoardLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE2_ScrumBoard_Poniatowski_Maximilian.Data
{
    public class ScrumBoardDbContext : DbContext
    {
        public ScrumBoardDbContext(DbContextOptions<ScrumBoardDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ScrumTask> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1 - fluent API
            //User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            //Status
            modelBuilder.Entity<Status>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Status>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            //Task
            modelBuilder.Entity<ScrumTask>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<ScrumTask>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ScrumTask>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);
            modelBuilder.Entity<ScrumTask>()
                .HasOne(t => t.Status)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.StatusId);
            modelBuilder.Entity<ScrumTask>()
                .Property(t => t.TaskDescription)
                .IsRequired(false);

            // 2 - DataBase Seeder

            var status = new Status[]
            {
                new Status{Id = 1, StatusName = "Open"},
                new Status{Id = 2, StatusName = "In Progress"},
                new Status{Id = 3, StatusName = "Done"},
            };

            modelBuilder.Entity<Status>()
                .HasData(status);

        }

    }
}
