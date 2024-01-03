using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2._web_API.Migrations
{
    public partial class Filme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Filmes",
                type: "longblob",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Filmes");
        }
    }
}
