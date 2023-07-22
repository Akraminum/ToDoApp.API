//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using System.Data;
//using ToDoAppAPI.Model;
//using ToDoAppAPI.Models;

//namespace ToDoAppAPI.DataBase
//{
//    public class AppDbContext : IdentityDbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//        public DbSet<TaskModel> Tasks { get; set; }
//        public DbSet<PriorityModel> priorities { get; set; }
//        public DbSet<StepModel> Steps { get; set; }
//        public DbSet<ListModel> Lists { get; set; }
//        public DbSet<UserModel> Users { get; set; }
//        public DbSet<UserListAccessModel> UsersLists { get; set; }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            SeedAdmins(modelBuilder);


//            modelBuilder.Entity<UserEntity>()
//                .HasMany(u => u.Lists)
//                .WithMany(l => l.Users)
//                .UsingEntity<UserListAccessEntity>();


//             =============== SEED ===============

//            modelBuilder.Entity<UserEntity>()
//                .HasData(new UserEntity[]
//                {
//                    new UserEntity {Id=1, FirstName="Tomas", LastName="Edison", Username="user1", Password="default"},
//                    new UserEntity {Id=2, FirstName="Albert", LastName="Maki", Username="user2", Password="default"},
//                });


//            modelBuilder.Entity<UserListAccessEntity>()
//                .HasData(new UserListAccessEntity[]
//                {
//                    new UserListAccessEntity{ Id=1, UserId=1, ListId=1},
//                    new UserListAccessEntity{ Id=2, UserId=1, ListId=2},

//                    new UserListAccessEntity{ Id=3, UserId=2, ListId=3},
//                    new UserListAccessEntity{ Id=4, UserId=2, ListId=4},

//                    new UserListAccessEntity{ Id=5, UserId=1, ListId=5},
//                    new UserListAccessEntity{ Id=6, UserId=2, ListId=5},
//                });

//            modelBuilder.Entity<PriorityEntity>()
//                .HasData(new PriorityEntity[]
//                {
//                    new PriorityEntity{Id=1, Name="P1", Order=1},
//                    new PriorityEntity{Id=2, Name="P2", Order=2},
//                    new PriorityEntity{Id=3, Name="P3", Order=3},
//                    new PriorityEntity{Id=4, Name="P4", Order=4},
//                    new PriorityEntity{Id=5, Name="P5", Order=5},
//                });

//            modelBuilder.Entity<TaskEntity>()
//                .HasData(new TaskEntity[]
//                {
//                    new TaskEntity{Id=1, Title="bay 2 pins", PriorityId=1, ListId=1, UserCreatedId=1},
//                    new TaskEntity{Id=2, Title="sell 2 pins hhh", PriorityId=1, ListId=1, UserCreatedId=1},

//                    new TaskEntity{Id=3, Title="make coffe", PriorityId=1, ListId=2, UserCreatedId=1},
//                    new TaskEntity{Id=4, Title="finish the vloge", PriorityId=1, ListId=2, UserCreatedId=1},

//                });
//        }

//        private void SeedAdmins(ModelBuilder builder)
//        {
//            string SUPER_ADMIN_ID = Guid.NewGuid().ToString();
//            string SUPER_ADMIN_ROLE_ID = Guid.NewGuid().ToString();

//            string ADMIN_ID = Guid.NewGuid().ToString();
//            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

//            seed admin role
//            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>()
//            {
//                new IdentityRole
//                {
//                    Id = SUPER_ADMIN_ROLE_ID,
//                    Name = "Admin",
//                    NormalizedName= "ADMIN",
//                }
//            });

//            #region Create User
//            create user
//            var AdminUser = new IdentityUser
//            {
//                Id = SUPER_ADMIN_ID,
//                Email = "admin@site.com",
//                EmailConfirmed = true,
//                UserName = "SuperAdmin",
//                NormalizedUserName = "SUPERADMIN"
//            };

//            set user password
//            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
//            AdminUser.PasswordHash = ph.HashPassword(AdminUser, "123qwe");

//            seed user
//            builder.Entity<IdentityUser>().HasData(AdminUser);
//            #endregion

//            set user role to admin
//            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
//            {
//                RoleId = SUPER_ADMIN_ROLE_ID,
//                UserId = SUPER_ADMIN_ID
//            });

//        }

//        private void Seed(ModelBuilder builder)
//        {
//            var role = Roles.Where(r => r.Name == "Admin").FirstOrDefault();
//            var user = Users.FirstOrDefault();

//            set user role to admin
//            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
//            {
//                UserId = user.Id,
//            });
//        }


//    }
//}
