using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class InicioBancoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalogo");

            migrationBuilder.CreateTable(
                name: "categoria",
                schema: "catalogo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                schema: "catalogo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    preco = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Stock = table.Column<decimal>(type: "numeric", nullable: false),
                    imagem = table.Column<string>(type: "varchar(250)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_produto_categoria_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "catalogo",
                        principalTable: "categoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "catalogo",
                table: "categoria",
                columns: new[] { "ID", "nome" },
                values: new object[,]
                {
                    { new Guid("de666796-44c3-4666-a0e5-c363521e2ead"), "Material Escolar" },
                    { new Guid("e74d91be-b74a-46a9-972c-6d3c02b480af"), "Eletrônicos" },
                    { new Guid("60e861ce-0210-4246-a40e-d5b31781a721"), "Acessorios" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_produto_CategoryId",
                schema: "catalogo",
                table: "produto",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto",
                schema: "catalogo");

            migrationBuilder.DropTable(
                name: "categoria",
                schema: "catalogo");
        }
    }
}
