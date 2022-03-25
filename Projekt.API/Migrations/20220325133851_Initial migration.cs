using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt.API.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: false),
                    ProjectNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    HoursWorked = table.Column<double>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeReports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Såggatan 4, 43295 Varberg", "Karl", "Karlsson", "0796524936" },
                    { 2, "Sångvägen 8, 13659 Skellefteå", "Tommy", "Nilsson", "0794632846" },
                    { 3, "Odengatan 46, 76519 Stockholm", "Jonna", "Mikaelsson", "0736428585" },
                    { 4, "Tomtevägen 50B, 26489 Malmö", "Mats", "Fransson", "0796524936" },
                    { 5, "Magistervägen 2, 43294 Varberg", "Dagny", "Svantesson", "0754256925" },
                    { 6, "Plåtgatan 9, 52648 Falkenberg", "Jens", "Haraldsson", "0706175289" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ProjectName", "ProjectNumber" },
                values: new object[,]
                {
                    { 1, "Kvarteret Nystaden", "55-2636" },
                    { 2, "Ombyggnad Kollebrien", "54-9462" },
                    { 3, "Kvarteret Yxan", "55-2856" },
                    { 4, "Ombyggnad Kommunhus C", "54-5454" },
                    { 5, "Renovering Villa Markström", "53-5521" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "Id", "Date", "EmployeeId", "HoursWorked", "ProjectId" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8.0, 5 },
                    { 1, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.0, 1 },
                    { 2, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.0, 1 },
                    { 3, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.0, 1 },
                    { 4, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.0, 1 },
                    { 9, new DateTime(2021, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 8.0, 1 },
                    { 5, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7.0, 3 },
                    { 6, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1.0, 4 },
                    { 7, new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8.0, 5 },
                    { 8, new DateTime(2021, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8.0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
