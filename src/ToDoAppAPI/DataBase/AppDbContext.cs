using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.DataBase
{
    public class AppDbContext: IdentityDbContext<UserEntity>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ListEntity> Lists { get; set; } = null!;
        public DbSet<TaskEntity> Tasks { get; set; } = null!;
        public DbSet<PriorityEntity> priorities { get; set; } = null!;
        public DbSet<StepEntity> Steps { get; set; } = null!;
        public DbSet<UsersLists> UsersLists { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedInitialUsersData.Seed(modelBuilder);
            
            #region ListEntity
            modelBuilder.Entity<ListEntity>()
                .HasMany(l => l.AssociatedUsers)
                .WithMany(u => u.AssociatedLists)
                .UsingEntity<UsersLists>(
                    j =>
                    {
                        j
                        .HasOne(pt => pt.User)
                        .WithMany(t => t.UsersLists)
                        .HasForeignKey(pt => pt.UserId);

                        j
                        .HasOne(pt => pt.List)
                        .WithMany(t => t.UsersLists)
                        .HasForeignKey(pt => pt.ListId)
                        .OnDelete(DeleteBehavior.NoAction);

                        j.HasKey(t => new { t.UserId, t.ListId });
                        j.ToTable("UsersLists");
                    }
                );

                modelBuilder.Entity<ListEntity>()
                .HasOne(l => l.Owner)
                .WithMany()
                .HasForeignKey(l => l.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<ListEntity>()
                .HasIndex(list => new{ list.OwnerId, list.Name })
                .IsUnique(true);
            #endregion

            #region TaskEntity
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Priority)
                .WithMany()
                .HasForeignKey(t => t.PriorityId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.UserCompleted)
                .WithMany()
                .HasForeignKey(t => t.UserCompletedId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region StepEntity
            modelBuilder.Entity<StepEntity>()
                .HasOne(s => s.Task)
                .WithMany(t => t.Steps)
                .HasForeignKey(s => s.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StepEntity>()
                .HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StepEntity>()
                .HasOne(t => t.UserCompleted)
                .WithMany()
                .HasForeignKey(t => t.UserCompletedId)
                .OnDelete(DeleteBehavior.Restrict);
            
            #endregion
        }
    }
}
