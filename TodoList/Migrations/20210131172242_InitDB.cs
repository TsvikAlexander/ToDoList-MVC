using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoListItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoListItems",
                columns: new[] { "Id", "AddDate", "IsDone", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 31, 19, 22, 41, 334, DateTimeKind.Local).AddTicks(2954), false, "Attend courses" },
                    { 2, new DateTime(2021, 1, 31, 19, 22, 41, 339, DateTimeKind.Local).AddTicks(3938), false, "Go to the store" },
                    { 3, new DateTime(2021, 1, 31, 19, 22, 41, 339, DateTimeKind.Local).AddTicks(4033), true, "Clean the house" },
                    { 4, new DateTime(2021, 1, 31, 19, 22, 41, 339, DateTimeKind.Local).AddTicks(4042), true, "Learn programming" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoListItems");
        }
    }
}
