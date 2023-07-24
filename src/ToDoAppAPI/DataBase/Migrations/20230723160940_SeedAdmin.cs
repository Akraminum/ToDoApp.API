using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e2f9568-61b6-4129-99d6-a8d3725cde6a", "a07aa530-3a97-49e4-8e9c-eb4cd6e3d6fe", "Admin", "Admin" },
                    { "9c59c5b3-e227-492c-9122-9acaea064531", "4959ccf7-8f07-4a47-ac3f-e8e1956adf85", "SuperAdmin", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9dbe76be-dd98-4bfe-bb7b-2bcd19a6f43b", 0, "6542247a-7d34-46be-9db4-3eb0bb7b3e7e", "superadmin@site.com", true, "admin", "admin", false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAEMtzuYMj36D3GW9Zg1zD28WjZJw75/CzVyozEURdvN0fyOFnteuS0dRzYizsf7YlWg==", null, false, "333f8c48-dba5-4a47-b841-79276c7ea56a", false, "SuperAdmin" },
                    { "aeaa4c68-ffa4-4804-af2e-282c4487c9e2", 0, "fd1721a5-feab-42fc-bc69-0df041ae6853", "admin@site.com", true, "admin", "admin", false, null, null, "Admin", "AQAAAAEAACcQAAAAEGCiFFF5LOEWwEZEbGzXAMlomlSa1mPEizvHnl8c5ytVghZxUUbtoFribvCWOodF6g==", null, false, "c51f0c10-dff8-4e08-a24a-3db18b6c7bb8", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9c59c5b3-e227-492c-9122-9acaea064531", "9dbe76be-dd98-4bfe-bb7b-2bcd19a6f43b" },
                    { "4e2f9568-61b6-4129-99d6-a8d3725cde6a", "aeaa4c68-ffa4-4804-af2e-282c4487c9e2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c59c5b3-e227-492c-9122-9acaea064531", "9dbe76be-dd98-4bfe-bb7b-2bcd19a6f43b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4e2f9568-61b6-4129-99d6-a8d3725cde6a", "aeaa4c68-ffa4-4804-af2e-282c4487c9e2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e2f9568-61b6-4129-99d6-a8d3725cde6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c59c5b3-e227-492c-9122-9acaea064531");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dbe76be-dd98-4bfe-bb7b-2bcd19a6f43b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aeaa4c68-ffa4-4804-af2e-282c4487c9e2");
        }
    }
}
