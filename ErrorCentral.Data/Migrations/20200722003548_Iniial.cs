using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErrorCentral.Data.Migrations
{
    public partial class Iniial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Organization = table.Column<string>(type: "varchar(250)", nullable: false),
                    Title = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", nullable: false),
                    Level = table.Column<string>(type: "varchar(100)", nullable: false),
                    Origin = table.Column<string>(type: "varchar(150)", nullable: false),
                    CollectedBy = table.Column<string>(type: "varchar(150)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
