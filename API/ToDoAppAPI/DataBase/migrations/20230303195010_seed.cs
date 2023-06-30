using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoAppAPI.database.migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "priorities",
                columns: new[] { "Id", "Color", "Name", "Order" },
                values: new object[,]
                {
                    { 1, "#ffffff", "P1", 1 },
                    { 2, "#ffffff", "P2", 2 },
                    { 3, "#ffffff", "P3", 3 },
                    { 4, "#ffffff", "P4", 4 },
                    { 5, "#ffffff", "P5", 5 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "DueDate", "IsComplete", "ListId", "PriorityId", "Title", "UserCreatedId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 3, 3, 21, 50, 10, 144, DateTimeKind.Local).AddTicks(4945), null, null, false, 1, 1, "bay 2 pins", 1 },
                    { 2, null, new DateTime(2023, 3, 3, 21, 50, 10, 144, DateTimeKind.Local).AddTicks(4954), null, null, false, 1, 1, "sell 2 pins hhh", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "priorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "priorities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "priorities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "priorities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "priorities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
