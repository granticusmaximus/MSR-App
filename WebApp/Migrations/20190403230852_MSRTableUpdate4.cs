using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class MSRTableUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmpID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "EmpID",
                table: "Tasks",
                newName: "AssignedEmpID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_EmpID",
                table: "Tasks",
                newName: "IX_Tasks_AssignedEmpID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_AssignedEmpID",
                table: "Tasks",
                column: "AssignedEmpID",
                principalTable: "Employees",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_AssignedEmpID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "AssignedEmpID",
                table: "Tasks",
                newName: "EmpID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignedEmpID",
                table: "Tasks",
                newName: "IX_Tasks_EmpID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmpID",
                table: "Tasks",
                column: "EmpID",
                principalTable: "Employees",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
