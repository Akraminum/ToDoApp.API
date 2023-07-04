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

        public DbSet<ListEntity> Lists { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<PriorityEntity> priorities { get; set; }
        //public DbSet<StepModel> Steps{ get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedInitialUsersData.Seed(modelBuilder);

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
                        .HasForeignKey(pt => pt.ListId);



                        j.HasKey(t => new { t.UserId, t.ListId });
                        j.ToTable("UsersLists");
                    }
                );

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Priority)
                .WithMany()
                .HasForeignKey(t => t.PriorityId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<StepEntity>()
                .HasOne(t => t.UserCreated)
                .WithMany()
                .HasForeignKey(t => t.UserCreatedId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}
