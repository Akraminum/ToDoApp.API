using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.database.migrations
{
    /// <inheritdoc />
    public partial class seeedo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 4, 0, 23, 16, 253, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 4, 0, 23, 16, 253, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "DueDate", "IsComplete", "ListId", "PriorityId", "Title", "UserCreatedId" },
                values: new object[,]
                {
                    { 3, null, new DateTime(2023, 3, 4, 0, 23, 16, 253, DateTimeKind.Local).AddTicks(2149), null, null, false, 2, 1, "make coffe", 1 },
                    { 4, null, new DateTime(2023, 3, 4, 0, 23, 16, 253, DateTimeKind.Local).AddTicks(2150), null, null, false, 2, 1, "finish the vloge", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 3, 21, 50, 10, 144, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 3, 21, 50, 10, 144, DateTimeKind.Local).AddTicks(4954));
        }
    }
}
