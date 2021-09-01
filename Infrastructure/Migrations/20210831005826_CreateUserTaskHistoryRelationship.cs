using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateUserTaskHistoryRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tasks History",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks History_UserId",
                table: "Tasks History",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks History_Users_UserId",
                table: "Tasks History",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks History_Users_UserId",
                table: "Tasks History");

            migrationBuilder.DropIndex(
                name: "IX_Tasks History_UserId",
                table: "Tasks History");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks History");
        }
    }
}
