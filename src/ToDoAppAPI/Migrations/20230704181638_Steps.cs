using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class Steps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "StepEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserCreatedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepEntity_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepEntity_Tasks_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5db03782-e490-4cc8-87c0-4e47ccda4011", "26991085-3a90-4ee1-8540-a4f52de28635", "SuperAdmin", "SuperAdmin" },
                    { "d01076ae-d6c5-4750-a05d-a67311630904", "36d64c85-2023-43d2-ae1b-afd0269a0566", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0e1ce120-3b9f-446f-be08-5f9ef2f3cdc9", 0, "dbf89617-fa3f-4091-9a75-d7273cfabfa7", "admin@site.com", true, "admin", "admin", false, null, null, "Admin", "AQAAAAEAACcQAAAAEDNjt1m5Jv0M9wDgU7Uo3KObly/uEePIflAq3Y3xy+nU4SPhZmCfOyfcx8SxYIUrqw==", null, false, "0226c553-55f4-4ce9-b3fa-557c3c9000da", false, "Admin" },
                    { "22bbc676-c1ce-4669-be87-173ac66decc1", 0, "1f90c57c-ca1c-4183-a75e-9884da58935d", "superadmin@site.com", true, "admin", "admin", false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAECNA9SCWYVBKk85k37Kqco/Q/56i2fc2QGE4VtSt7qH9+Ej7ajS8imJDtkJQPsUG/g==", null, false, "811a7fdc-d0a0-4e31-9657-c20a57afb523", false, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d01076ae-d6c5-4750-a05d-a67311630904", "0e1ce120-3b9f-446f-be08-5f9ef2f3cdc9" },
                    { "5db03782-e490-4cc8-87c0-4e47ccda4011", "22bbc676-c1ce-4669-be87-173ac66decc1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StepEntity_TaskId",
                table: "StepEntity",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_StepEntity_UserCreatedId",
                table: "StepEntity",
                column: "UserCreatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StepEntity");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d01076ae-d6c5-4750-a05d-a67311630904", "0e1ce120-3b9f-446f-be08-5f9ef2f3cdc9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5db03782-e490-4cc8-87c0-4e47ccda4011", "22bbc676-c1ce-4669-be87-173ac66decc1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5db03782-e490-4cc8-87c0-4e47ccda4011");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d01076ae-d6c5-4750-a05d-a67311630904");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e1ce120-3b9f-446f-be08-5f9ef2f3cdc9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22bbc676-c1ce-4669-be87-173ac66decc1");

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
        }
    }
}
