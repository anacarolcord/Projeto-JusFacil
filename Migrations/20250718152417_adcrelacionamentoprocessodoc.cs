using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JusFacil.API.Migrations
{
    /// <inheritdoc />
    public partial class adcrelacionamentoprocessodoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessoId",
                table: "Documentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ProcessoId",
                table: "Documentos",
                column: "ProcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Processos_ProcessoId",
                table: "Documentos",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "ProcessoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Processos_ProcessoId",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_ProcessoId",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "ProcessoId",
                table: "Documentos");
        }
    }
}
