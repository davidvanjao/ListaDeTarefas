using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ListaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBanco2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "CategoriaId", "DataDeVencimento", "Descricao", "StatusId" },
                values: new object[,]
                {
                    { 1, "casa", new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpar Casa", "aberto" },
                    { 2, "faculdade", new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fazer tarefa", "aberto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarefas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tarefas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
