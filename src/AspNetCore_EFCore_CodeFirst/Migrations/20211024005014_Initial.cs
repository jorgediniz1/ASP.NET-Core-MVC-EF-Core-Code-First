using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore_EFCore_CodeFirst.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(150)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Livro_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 1, "Software" });

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "ID", "Autor", "CategoriaID", "DataEntrada", "Preco", "Quantidade", "Titulo" },
                values: new object[] { 1, "Tomas Harris", 1, new DateTime(2021, 10, 23, 21, 50, 14, 4, DateTimeKind.Local).AddTicks(7579), 40.20m, 10, "O Silêncio dos Inocentes" });

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "ID", "Autor", "CategoriaID", "DataEntrada", "Preco", "Quantidade", "Titulo" },
                values: new object[] { 2, "Robert Cecil Martin", 1, new DateTime(2021, 10, 23, 21, 50, 14, 6, DateTimeKind.Local).AddTicks(2988), 78.10m, 15, "Clean Code" });

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "ID", "Autor", "CategoriaID", "DataEntrada", "Preco", "Quantidade", "Titulo" },
                values: new object[] { 3, "Kent Beck e Martin Fowler", 1, new DateTime(2021, 10, 23, 21, 50, 14, 6, DateTimeKind.Local).AddTicks(3023), 40.20m, 10, "Refatoração: Aperfeiçoando o Projeto de Código Existente" });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_CategoriaID",
                table: "Livro",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Titulo",
                table: "Livro",
                column: "Titulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
