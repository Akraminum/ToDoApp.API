using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "418b7878-e84f-4ec4-adfe-af185e4287ef", "d6791198-0853-4ed8-ad69-ddb047ec95c3", "SuperAdmin", "SuperAdmin" },
                    { "b46db6c5-c6bd-484e-bf49-7a4d3704c4db", "25ea29b0-b7f3-49b4-be33-51e4a06d680d", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5b9f1a58-5e23-4983-a50a-4cf26e51fb05", 0, "3337642d-bd62-4773-90b3-3b204d12547b", "superadmin@site.com", true, "admin", "admin", false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAEKsVS+/JyQON0kgTYq4zbKF8J2yuRgIAr6O+uyHXLYVQJAlzBGajQq+JlGSe21334w==", null, false, "40f52738-2af0-44b0-bcd9-05854f69d040", false, "SuperAdmin" },
                    { "92d6e1af-cd2b-4f97-9221-9b380afec500", 0, "1a1ac41e-3732-465e-b54a-d3d9a4ac591a", "admin@site.com", true, "admin", "admin", false, null, null, "Admin", "AQAAAAEAACcQAAAAEMcLsJXmEJESFZ//25VrLrkXN88I8tOFcLIyeQA6nVFSMzMFFooNjwaIDNhCvt3PWQ==", null, false, "be0f5c3c-45c4-46ca-916e-987f1c5987d1", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "418b7878-e84f-4ec4-adfe-af185e4287ef", "5b9f1a58-5e23-4983-a50a-4cf26e51fb05" },
                    { "b46db6c5-c6bd-484e-bf49-7a4d3704c4db", "92d6e1af-cd2b-4f97-9221-9b380afec500" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "418b7878-e84f-4ec4-adfe-af185e4287ef", "5b9f1a58-5e23-4983-a50a-4cf26e51fb05" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b46db6c5-c6bd-484e-bf49-7a4d3704c4db", "92d6e1af-cd2b-4f97-9221-9b380afec500" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "418b7878-e84f-4ec4-adfe-af185e4287ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b46db6c5-c6bd-484e-bf49-7a4d3704c4db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b9f1a58-5e23-4983-a50a-4cf26e51fb05");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92d6e1af-cd2b-4f97-9221-9b380afec500");
        }
    }
}
