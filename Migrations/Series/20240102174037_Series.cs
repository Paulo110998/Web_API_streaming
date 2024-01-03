using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2._web_API.Migrations.Series
{
    public partial class Series : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImagemSerie",
                table: "Seriess",
                type: "longblob",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemSerie",
                table: "Seriess");
        }
    }
}
