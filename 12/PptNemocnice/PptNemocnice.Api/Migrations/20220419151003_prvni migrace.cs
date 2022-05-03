using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class prvnimigrace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vybavenis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PriceCzk = table.Column<int>(type: "INTEGER", nullable: false),
                    BoughtDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastRevision = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vybavenis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vybavenis");
        }
    }
}
