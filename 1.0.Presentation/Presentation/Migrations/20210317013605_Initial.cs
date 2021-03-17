using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presentation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeletionDate = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: false),
                    Login = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeletionDate = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    ClinicUnitId = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ClinicUnit_ClinicUnitId",
                        column: x => x.ClinicUnitId,
                        principalTable: "ClinicUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeletionDate = table.Column<DateTime>(nullable: false),
                    ScheduleDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ClinicUnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_ClinicUnit_ClinicUnitId",
                        column: x => x.ClinicUnitId,
                        principalTable: "ClinicUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClinicUnitId",
                table: "Schedule",
                column: "ClinicUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_UserId",
                table: "Schedule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ClinicUnitId",
                table: "User",
                column: "ClinicUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ClinicUnit");
        }
    }
}
