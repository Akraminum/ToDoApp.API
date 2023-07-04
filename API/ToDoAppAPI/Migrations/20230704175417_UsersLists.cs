using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class UsersLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersLists",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    AccessLevel = table.Column<byte>(type: "tinyint", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersLists_ListId",
                table: "UsersLists",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersLists");

            migrationBuilder.DropTable(
                name: "Lists");

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
    }
}
