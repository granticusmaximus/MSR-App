using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class MSRTableUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Apps_AppID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AppID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "AppID",
                table: "Tasks",
                newName: "AssignedAppID");

            migrationBuilder.AddColumn<int>(
                name: "AppsAppID",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AppsAppID",
                table: "Tasks",
                column: "AppsAppID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Apps_AppsAppID",
                table: "Tasks",
                column: "AppsAppID",
                principalTable: "Apps",
                principalColumn: "AppID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Apps_AppsAppID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AppsAppID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AppsAppID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "AssignedAppID",
                table: "Tasks",
                newName: "AppID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AppID",
                table: "Tasks",
                column: "AppID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Apps_AppID",
                table: "Tasks",
                column: "AppID",
                principalTable: "Apps",
                principalColumn: "AppID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
