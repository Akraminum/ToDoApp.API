using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Utitlities.Auth;

namespace ToDoAppAPI.DataBase
{
    public static class SeedInitialUsersData
    {
        private static string
            SUPER_ADMIN_ID = Guid.NewGuid().ToString(),
            ADMIN_ID = Guid.NewGuid().ToString(),
            SUPER_ADMIN_ROLE_ID = Guid.NewGuid().ToString(),
            ADMIN_ROLE_ID = Guid.NewGuid().ToString();

        public static void Seed(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedAdmins(builder);
            AssignRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            //seed admin role
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = SUPER_ADMIN_ROLE_ID,
                    Name = Roles.SuperAdmin,
                    NormalizedName= Roles.SuperAdmin,
                },
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = Roles.Admin,
                    NormalizedName= Roles.Admin,
                }
            });
        }
        
        private static void SeedAdmins(ModelBuilder builder)
        {
            //create users
            var SuperAdmin = new UserEntity
            {
                Id = SUPER_ADMIN_ID,
                FirstName = "admin",
                LastName = "admin",
                Email = "superadmin@site.com",
                EmailConfirmed = true,
                UserName = "SuperAdmin",
                NormalizedUserName = "SUPERADMIN"
            };
            var Admin = new UserEntity
            {
                Id = ADMIN_ID,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@site.com",
                EmailConfirmed = true,
                UserName = "Admin",
                NormalizedUserName = "Admin"
            };

            //set user password
            PasswordHasher<UserEntity> ph = new PasswordHasher<UserEntity>();
            SuperAdmin.PasswordHash = ph.HashPassword(SuperAdmin, "123qwe");
            Admin.PasswordHash = ph.HashPassword(Admin, "123qwe");

            //seed user
            builder.Entity<UserEntity>().HasData(SuperAdmin, Admin);

        }

        private static void AssignRoles(ModelBuilder builder)
        {
            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    UserId = SUPER_ADMIN_ID,
                    RoleId = SUPER_ADMIN_ROLE_ID
                },
                new IdentityUserRole<string>
                {
                    UserId = ADMIN_ID,
                    RoleId = ADMIN_ROLE_ID
                },
            });
        }
    }
}
