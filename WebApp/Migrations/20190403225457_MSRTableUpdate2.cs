using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class MSRTableUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Apps_AppsAppID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_AssignedEmp",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AppsAppID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AppsAppID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "AssignedEmp",
                table: "Tasks",
                newName: "EmpID");

            migrationBuilder.RenameColumn(
                name: "AssignedApp",
                table: "Tasks",
                newName: "AppID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignedEmp",
                table: "Tasks",
                newName: "IX_Tasks_EmpID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmpID",
                table: "Tasks",
                column: "EmpID",
                principalTable: "Employees",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Apps_AppID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmpID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AppID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "EmpID",
                table: "Tasks",
                newName: "AssignedEmp");

            migrationBuilder.RenameColumn(
                name: "AppID",
                table: "Tasks",
                newName: "AssignedApp");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_EmpID",
                table: "Tasks",
                newName: "IX_Tasks_AssignedEmp");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_AssignedEmp",
                table: "Tasks",
                column: "AssignedEmp",
                principalTable: "Employees",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
