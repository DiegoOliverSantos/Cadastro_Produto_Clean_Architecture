using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Data.Migrations
{
    public partial class CriarColunaDesativado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "catalogo",
                table: "categoria",
                keyColumn: "ID",
                keyValue: new Guid("60e861ce-0210-4246-a40e-d5b31781a721"));

            migrationBuilder.DeleteData(
                schema: "catalogo",
                table: "categoria",
                keyColumn: "ID",
                keyValue: new Guid("de666796-44c3-4666-a0e5-c363521e2ead"));

            migrationBuilder.DeleteData(
                schema: "catalogo",
                table: "categoria",
                keyColumn: "ID",
                keyValue: new Guid("e74d91be-b74a-46a9-972c-6d3c02b480af"));

            migrationBuilder.AddColumn<bool>(
                name: "Desativado",
                schema: "catalogo",
                table: "produto",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Desativado",
                schema: "catalogo",
                table: "categoria",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desativado",
                schema: "catalogo",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "Desativado",
                schema: "catalogo",
                table: "categoria");

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
        }
    }
}
