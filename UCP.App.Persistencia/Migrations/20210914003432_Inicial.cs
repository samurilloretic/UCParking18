using Microsoft.EntityFrameworkCore.Migrations;

namespace UCP.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identificacion = table.Column<int>(type: "int", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condicionEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vehiculo_1id = table.Column<int>(type: "int", nullable: true),
                    Vehiculo_2id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_personas_Vehiculo_Vehiculo_1id",
                        column: x => x.Vehiculo_1id,
                        principalTable: "Vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_Vehiculo_Vehiculo_2id",
                        column: x => x.Vehiculo_2id,
                        principalTable: "Vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personas_Vehiculo_1id",
                table: "personas",
                column: "Vehiculo_1id");

            migrationBuilder.CreateIndex(
                name: "IX_personas_Vehiculo_2id",
                table: "personas",
                column: "Vehiculo_2id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
