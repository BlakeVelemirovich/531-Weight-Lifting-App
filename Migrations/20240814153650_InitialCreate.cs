using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _531WorkoutApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "PassFailHistories",
                columns: table => new
                {
                    HistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Week = table.Column<int>(type: "integer", nullable: false),
                    Passed = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassFailHistories", x => x.HistoryId);
                });

            migrationBuilder.CreateTable(
                name: "UserExercises",
                columns: table => new
                {
                    UserExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentWeek = table.Column<int>(type: "integer", nullable: false),
                    OneRepMax = table.Column<float>(type: "real", nullable: false),
                    CurrentWeight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercises", x => x.UserExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "PassFailHistories");

            migrationBuilder.DropTable(
                name: "UserExercises");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
