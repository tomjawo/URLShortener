using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace URLShortener.Migrations
{
    public partial class AddedClicks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clicks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClickedCount = table.Column<int>(nullable: false),
                    urlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clicks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clicks_URLs_urlId",
                        column: x => x.urlId,
                        principalTable: "URLs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clicks_urlId",
                table: "Clicks",
                column: "urlId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clicks");
        }
    }
}
