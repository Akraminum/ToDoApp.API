using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class refine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StepEntity_Tasks_TaskId",
                table: "StepEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_StepEntity_Tasks_UserCreatedId",
                table: "StepEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StepEntity",
                table: "StepEntity");

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

            migrationBuilder.RenameTable(
                name: "StepEntity",
                newName: "Steps");

            migrationBuilder.RenameIndex(
                name: "IX_StepEntity_UserCreatedId",
                table: "Steps",
                newName: "IX_Steps_UserCreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_StepEntity_TaskId",
                table: "Steps",
                newName: "IX_Steps_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Steps",
                table: "Steps",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "310ba4f4-225e-47dd-b1b4-477471582b48", "d2be19d8-f7ba-4bb6-9167-a37107a2771d", "SuperAdmin", "SuperAdmin" },
                    { "3257de1f-29a1-49a3-85f4-36022812f84d", "0b1ecd3f-bbba-475f-ae49-ccf079489555", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "38ef645d-4ec8-44ab-9208-696dc87c7c22", 0, "50b43f6d-e04e-4e66-8f92-f4be129ed9c3", "superadmin@site.com", true, "admin", "admin", false, null, null, "SUPERADMIN", "AQAAAAEAACcQAAAAEL2nAFiSVZOsK7Y9ED3w9z2Qnul1lVt6jnEjJZU2M96NIqpL2m6qUT8JJzcDRYvIYQ==", null, false, "e7fb68cf-6fb8-4d90-85fa-60a6e6b5a05b", false, "SuperAdmin" },
                    { "f52c59c1-e35b-4f01-a480-b4542653fd9c", 0, "323f6baf-4aa4-4a28-8677-bebe21f5e778", "admin@site.com", true, "admin", "admin", false, null, null, "Admin", "AQAAAAEAACcQAAAAEK4Wbt9LV/Yw5cUZFumcSJph039FkpEv0OaVftLNbNOdZY//jeysiz8BNMvxRQoAqA==", null, false, "c61821e4-f60f-46f9-9436-a01e83815d18", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "310ba4f4-225e-47dd-b1b4-477471582b48", "38ef645d-4ec8-44ab-9208-696dc87c7c22" },
                    { "3257de1f-29a1-49a3-85f4-36022812f84d", "f52c59c1-e35b-4f01-a480-b4542653fd9c" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Tasks_TaskId",
                table: "Steps",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Tasks_UserCreatedId",
                table: "Steps",
                column: "UserCreatedId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Tasks_TaskId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Tasks_UserCreatedId",
                table: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Steps",
                table: "Steps");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "310ba4f4-225e-47dd-b1b4-477471582b48", "38ef645d-4ec8-44ab-9208-696dc87c7c22" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3257de1f-29a1-49a3-85f4-36022812f84d", "f52c59c1-e35b-4f01-a480-b4542653fd9c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310ba4f4-225e-47dd-b1b4-477471582b48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3257de1f-29a1-49a3-85f4-36022812f84d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ef645d-4ec8-44ab-9208-696dc87c7c22");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f52c59c1-e35b-4f01-a480-b4542653fd9c");

            migrationBuilder.RenameTable(
                name: "Steps",
                newName: "StepEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_UserCreatedId",
                table: "StepEntity",
                newName: "IX_StepEntity_UserCreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_TaskId",
                table: "StepEntity",
                newName: "IX_StepEntity_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StepEntity",
                table: "StepEntity",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StepEntity_Tasks_TaskId",
                table: "StepEntity",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StepEntity_Tasks_UserCreatedId",
                table: "StepEntity",
                column: "UserCreatedId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
