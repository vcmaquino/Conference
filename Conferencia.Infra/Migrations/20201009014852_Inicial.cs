using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conference.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    NomeDoConsumidor = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Bebida = table.Column<string>(nullable: true),
                    Embalagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
