using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientesApp.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosCiviles",
                columns: table => new
                {
                    EstadoCivilID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCiviles", x => x.EstadoCivilID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID_Cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: true),
                    Genero = table.Column<bool>(nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(nullable: false),
                    EstadoCivilID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID_Cliente);
                    table.ForeignKey(
                        name: "FK_Clientes_EstadosCiviles_EstadoCivilID",
                        column: x => x.EstadoCivilID,
                        principalTable: "EstadosCiviles",
                        principalColumn: "EstadoCivilID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EstadoCivilID",
                table: "Clientes",
                column: "EstadoCivilID");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Identificacion",
                table: "Clientes",
                column: "Identificacion",
                unique: true,
                filter: "[Identificacion] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadosCiviles");
        }
    }
}
