using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTaskDemo.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleTaskCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTaskCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleTaskCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleTask_ScheduleTaskCategory_ScheduleTaskCategoryId",
                        column: x => x.ScheduleTaskCategoryId,
                        principalTable: "ScheduleTaskCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleTask_ScheduleTaskCategoryId",
                table: "ScheduleTask",
                column: "ScheduleTaskCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleTask");

            migrationBuilder.DropTable(
                name: "ScheduleTaskCategory");
        }
    }
}
