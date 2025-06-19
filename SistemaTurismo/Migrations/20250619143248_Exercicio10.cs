using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurismo.Migrations
{
    /// <inheritdoc />
    public partial class Exercicio10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Clientes_ClienteId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Destinos_PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.CreateTable(
                name: "DestinoPacoteTuristico",
                columns: table => new
                {
                    DestinosId = table.Column<int>(type: "INTEGER", nullable: false),
                    PacoteTuristicoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoPacoteTuristico", x => new { x.DestinosId, x.PacoteTuristicoId });
                    table.ForeignKey(
                        name: "FK_DestinoPacoteTuristico_Destinos_DestinosId",
                        column: x => x.DestinosId,
                        principalTable: "Destinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinoPacoteTuristico_PacotesTuristicos_PacoteTuristicoId",
                        column: x => x.PacoteTuristicoId,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinoPacoteTuristico_PacoteTuristicoId",
                table: "DestinoPacoteTuristico",
                column: "PacoteTuristicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Clientes_ClienteId",
                table: "Reservas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Clientes_ClienteId",
                table: "Reservas");

            migrationBuilder.DropTable(
                name: "DestinoPacoteTuristico");

            migrationBuilder.AddColumn<int>(
                name: "PacoteTuristicoId",
                table: "Destinos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_PacotesTuristicos_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId",
                principalTable: "PacotesTuristicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Clientes_ClienteId",
                table: "Reservas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
