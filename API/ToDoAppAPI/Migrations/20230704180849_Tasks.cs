using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class Tasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5fd9791-0841-458f-bf8b-6b419f567665", "3d0e6a4d-45e4-409e-90b9-18c449e90ea5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad36de2a-9d4c-4dae-93a9-61bd455e6687", "9367e1f4-a44a-404e-934e-276872bc6e81" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad36de2a-9d4c-4dae-93a9-61bd455e6687");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5fd9791-0841-458f-bf8b-6b419f567665");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0e6a4d-45e4-409e-90b9-18c449e90ea5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9367e1f4-a44a-404e-934e-276872bc6e81");

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
                    UserCreatedId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3910e785-d0b4-4f87-8228-ba4f735f7240", "3643f1a1-50ea-4741-ac57-cdde318df616", "Admin", "Admin" },
                    { "c2309973-440e-4790-a9cb-c139e7609668", "878bf167-9ddc-4afb-9899-97174e504a58", "SuperAdmin", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a084cf3d-4d1e-439c-971b-438f5d59bc17", 0, "b01f61a0-bad0-4ec6-b05c-142a6a6f6c26", "admin@site.com", true, "admin", "admin", false, null, null, "Admin", "AQAAAAEAACcQAAAAEDD8m+M5caP8J0v9qmq/xyQtLrfdFGSUZGE2oNhOBevw+fAGjGEMxPxnWicgRqpalQ==", null, false, "bd87bca3-dc65-4e0c-bc28-2c5bdde95b37", false, "Admin" },
                    { "eded6294-4fda-4bc7-ae51-3ca8e116a805", 0, "d72d4cf5-b025-45ca-8dca-4a37f7474c0f", "superadmin@site.com", true, "admin", "admin", false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAECROrWxtkPS6qwM73zDYIz47Ti7A/t7oLXya52fsfTrocoNsHiBrC59vwrPlZ2AkJg==", null, false, "4fdd1455-3905-4e67-94c3-17b8a4e505a7", false, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3910e785-d0b4-4f87-8228-ba4f735f7240", "a084cf3d-4d1e-439c-971b-438f5d59bc17" },
                    { "c2309973-440e-4790-a9cb-c139e7609668", "eded6294-4fda-4bc7-ae51-3ca8e116a805" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ListId",
                table: "Tasks",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserCreatedId",
                table: "Tasks",
                column: "UserCreatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "priorities");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3910e785-d0b4-4f87-8228-ba4f735f7240", "a084cf3d-4d1e-439c-971b-438f5d59bc17" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c2309973-440e-4790-a9cb-c139e7609668", "eded6294-4fda-4bc7-ae51-3ca8e116a805" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3910e785-d0b4-4f87-8228-ba4f735f7240");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2309973-440e-4790-a9cb-c139e7609668");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a084cf3d-4d1e-439c-971b-438f5d59bc17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eded6294-4fda-4bc7-ae51-3ca8e116a805");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad36de2a-9d4c-4dae-93a9-61bd455e6687", "cb0010d7-4a1b-4937-9cfd-354254780ec1", "Admin", "Admin" },
                    { "c5fd9791-0841-458f-bf8b-6b419f567665", "465c1644-228e-45dc-9da9-a0b7b85eb110", "SuperAdmin", "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3d0e6a4d-45e4-409e-90b9-18c449e90ea5", 0, "504ccc14-7f61-4afd-84ff-fd8b65940795", "superadmin@site.com", true, "admin", "admin", false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAEOKVoW3fDhBs2DxKKw9sfv1/Ah5mSOP7xjm4m8USTNzQL7trpOdVTGhUE9Jowj1KMg==", null, false, "54a21445-1fcb-4f57-92ee-db7338c0af97", false, "SuperAdmin" },
                    { "9367e1f4-a44a-404e-934e-276872bc6e81", 0, "cd69c4df-fcbd-4b8f-8736-b7792f575e70", "admin@site.com", true, "admin", "admin", false, null, null, "Admin", "AQAAAAEAACcQAAAAEIFPFJ6VcZfeYCRQCqrk3nz0aqh2oRZuVlSq+tP9484p34uTNrINe4lZkB4KWsojhQ==", null, false, "ec64051a-d5af-4648-9088-cccd60e90a4b", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c5fd9791-0841-458f-bf8b-6b419f567665", "3d0e6a4d-45e4-409e-90b9-18c449e90ea5" },
                    { "ad36de2a-9d4c-4dae-93a9-61bd455e6687", "9367e1f4-a44a-404e-934e-276872bc6e81" }
                });
        }
    }
}
