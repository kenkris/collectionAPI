using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CollectionAPI.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OringCity",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "OringCountry",
                table: "Artist");

            migrationBuilder.AddColumn<string>(
                name: "OriginCity",
                table: "Artist",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginCountry",
                table: "Artist",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginCity",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "OriginCountry",
                table: "Artist");

            migrationBuilder.AddColumn<string>(
                name: "OringCity",
                table: "Artist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OringCountry",
                table: "Artist",
                nullable: true);
        }
    }
}
