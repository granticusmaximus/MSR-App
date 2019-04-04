using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class CreateAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analysts",
                columns: table => new
                {
                    BAID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BAFName = table.Column<string>(nullable: true),
                    BALName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysts", x => x.BAID);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DevID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DevFName = table.Column<string>(nullable: true),
                    DevLName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DevID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    AppID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppName = table.Column<string>(nullable: true),
                    AssignedBA = table.Column<int>(nullable: false),
                    AssignedDev = table.Column<int>(nullable: false),
                    AppNotes = table.Column<string>(nullable: true),
                    POC = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    POCEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.AppID);
                    table.ForeignKey(
                        name: "FK_Apps_Analysts_AssignedBA",
                        column: x => x.AssignedBA,
                        principalTable: "Analysts",
                        principalColumn: "BAID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apps_Developers_AssignedDev",
                        column: x => x.AssignedDev,
                        principalTable: "Developers",
                        principalColumn: "DevID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    MsrID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedEmp = table.Column<int>(nullable: false),
                    AssignedApp = table.Column<int>(nullable: false),
                    AppsAppID = table.Column<int>(nullable: true),
                    MSRtitle = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    MSRNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.MsrID);
                    table.ForeignKey(
                        name: "FK_Tasks_Apps_AppsAppID",
                        column: x => x.AppsAppID,
                        principalTable: "Apps",
                        principalColumn: "AppID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_AssignedEmp",
                        column: x => x.AssignedEmp,
                        principalTable: "Employees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apps_AssignedBA",
                table: "Apps",
                column: "AssignedBA");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_AssignedDev",
                table: "Apps",
                column: "AssignedDev");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AppsAppID",
                table: "Tasks",
                column: "AppsAppID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedEmp",
                table: "Tasks",
                column: "AssignedEmp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Analysts");

            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
