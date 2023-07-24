using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AppTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lists_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersLists",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLists", x => new { x.UserId, x.ListId });
                    table.ForeignKey(
                        name: "FK_UsersLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersLists_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserCompletedId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserCompletedId",
                        column: x => x.UserCompletedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    UserCompletedId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_AspNetUsers_UserCompletedId",
                        column: x => x.UserCompletedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_Tasks_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "687cac65-58c1-4bbe-b77f-ed566d8b6058", "b8fbefaa-7a80-431f-a8ca-464b58ab9d82", "SuperAdmin", "SuperAdmin" },
                    { "87f5da21-78ae-4550-a9e4-1485196a0b53", "bc54b1a9-ba0d-4916-94bc-cd20f0a697c6", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8c260fcf-6d61-474c-871f-1e5a2e5c0ac2", 0, "64d51411-6902-46bb-affa-b7ceb3b3b749", "superadmin@site.com", true, "admin", "admin", false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAEGQLeFXHsbEuXGGECfXBuV6/9ZsG7v5UWGrkRlBXLrkJ695cGzKgn9sieIeZ6PhYhg==", null, false, "b1dd2755-8789-44f9-8c45-b41b59bec660", false, "SuperAdmin" },
                    { "da28bcb9-930a-4b7c-9eee-fc1dfe347fed", 0, "70f89270-0d2b-4d92-ae88-426b41370257", "admin@site.com", true, "admin", "admin", false, null, null, "Admin", "AQAAAAEAACcQAAAAEMgnkLFJKGWZ/xTjaHa9w/6Fnle4tXRvyOfHG76qtavYQ7kjNLCTUzTMMKkVuOmrSQ==", null, false, "c1fc2e70-42da-47a9-b5fa-2f9e0c13030a", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "687cac65-58c1-4bbe-b77f-ed566d8b6058", "8c260fcf-6d61-474c-871f-1e5a2e5c0ac2" },
                    { "87f5da21-78ae-4550-a9e4-1485196a0b53", "da28bcb9-930a-4b7c-9eee-fc1dfe347fed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lists_OwnerId_Name",
                table: "Lists",
                columns: new[] { "OwnerId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_OwnerId",
                table: "Steps",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TaskId",
                table: "Steps",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_UserCompletedId",
                table: "Steps",
                column: "UserCompletedId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ListId",
                table: "Tasks",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserCompletedId",
                table: "Tasks",
                column: "UserCompletedId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLists_ListId",
                table: "UsersLists",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "UsersLists");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "priorities");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "687cac65-58c1-4bbe-b77f-ed566d8b6058", "8c260fcf-6d61-474c-871f-1e5a2e5c0ac2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "87f5da21-78ae-4550-a9e4-1485196a0b53", "da28bcb9-930a-4b7c-9eee-fc1dfe347fed" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "687cac65-58c1-4bbe-b77f-ed566d8b6058");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87f5da21-78ae-4550-a9e4-1485196a0b53");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c260fcf-6d61-474c-871f-1e5a2e5c0ac2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da28bcb9-930a-4b7c-9eee-fc1dfe347fed");

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
    }
}
