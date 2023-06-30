using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.Model;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.DataBase
{
    public class AppDbContext: IdentityDbContext  
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<PriorityModel> priorities{ get; set; }
        public DbSet<StepModel> Steps{ get; set; } 
        public DbSet<ListModel> Lists { get; set; }
        public DbSet<UserModel> Users{ get; set; }
        public DbSet<UserListAccessModel> UsersLists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Lists)
                .WithMany(l => l.Users)
                .UsingEntity<UserListAccessModel>();


            // =============== SEED ===============

            modelBuilder.Entity<UserModel>()
                .HasData(new UserModel[]
                {
                    new UserModel {Id=1, FirstName="Tomas", LastName="Edison", Username="user1", Password="default"},
                    new UserModel {Id=2, FirstName="Albert", LastName="Maki", Username="user2", Password="default"},
                });

            modelBuilder.Entity<ListModel>()
                .HasData(new ListModel[]
                {
                    new ListModel{Id=1, Name="shopping A"},
                    new ListModel{Id=2, Name="To Do A"},

                    new ListModel{Id=3, Name="shopping B"},
                    new ListModel{Id=4, Name="To Do B"},

                    new ListModel{Id=5, Name="Shardo"},
                });

            modelBuilder.Entity<UserListAccessModel>()
                .HasData(new UserListAccessModel[]
                {
                    new UserListAccessModel{ Id=1, UserId=1, ListId=1},
                    new UserListAccessModel{ Id=2, UserId=1, ListId=2},

                    new UserListAccessModel{ Id=3, UserId=2, ListId=3},
                    new UserListAccessModel{ Id=4, UserId=2, ListId=4},

                    new UserListAccessModel{ Id=5, UserId=1, ListId=5},
                    new UserListAccessModel{ Id=6, UserId=2, ListId=5},
                });

            modelBuilder.Entity<PriorityModel>()
                .HasData(new PriorityModel[]
                {
                    new PriorityModel{Id=1, Name="P1", Order=1},
                    new PriorityModel{Id=2, Name="P2", Order=2},
                    new PriorityModel{Id=3, Name="P3", Order=3},
                    new PriorityModel{Id=4, Name="P4", Order=4},
                    new PriorityModel{Id=5, Name="P5", Order=5},
                });

            modelBuilder.Entity<TaskModel>()
                .HasData(new TaskModel[]
                {
                    new TaskModel{Id=1, Title="bay 2 pins", PriorityId=1, ListId=1, UserCreatedId=1},
                    new TaskModel{Id=2, Title="sell 2 pins hhh", PriorityId=1, ListId=1, UserCreatedId=1},

                    new TaskModel{Id=3, Title="make coffe", PriorityId=1, ListId=2, UserCreatedId=1},
                    new TaskModel{Id=4, Title="finish the vloge", PriorityId=1, ListId=2, UserCreatedId=1},

                });
        }

    }
}
